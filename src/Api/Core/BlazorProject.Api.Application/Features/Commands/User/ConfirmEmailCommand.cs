using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User;

public class ConfirmEmailCommand:IRequest<bool>
{
    public Guid ConfirmationId { get; set; }
}

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailConfirmRepository _emailConfirmRepository;

    public ConfirmEmailHandler(IUserRepository userRepository, IEmailConfirmRepository emailConfirmRepository)
    {
        _userRepository = userRepository;
        _emailConfirmRepository = emailConfirmRepository;
    }


    public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var confirmation = await _emailConfirmRepository.GetById(request.ConfirmationId);

        if (confirmation is null)
            throw new DbValidEx("Confirm not found");
        

        var dbUser = await _userRepository.GetById(request.ConfirmationId);

        if (dbUser is null)
            throw new DbValidEx("User not found");
        
        if (dbUser.Status)
            throw new DbValidEx("Email allready confirmed");

        dbUser.Status = true;

        await _userRepository.Update(dbUser);

        return true;
    }
}