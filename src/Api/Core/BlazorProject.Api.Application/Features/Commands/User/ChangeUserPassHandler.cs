using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Models.CommandModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User;

public class ChangeUserPassHandler : IRequestHandler<ChangeUserPassCommand, bool>
{
    private readonly IUserRepository _repository;

    public ChangeUserPassHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(ChangeUserPassCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _repository.GetById(request.UserId);

        if (dbUser is null)
            throw new DbValidEx("User not found");

        if (dbUser.Pass != request.OldPass)
            throw new DbValidEx("Old password is not correct");

        dbUser.Pass = request.NewPass;

        await _repository.Update(dbUser);

        return true;    
    }
}
