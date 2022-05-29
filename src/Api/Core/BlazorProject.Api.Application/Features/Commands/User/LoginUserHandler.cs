using AutoMapper;
using BlazorProject.Api.Application.Interfaces.Repositories;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Models.CommandModel;
using BlazorProject.Common.Models.ViewModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Features.Commands.User;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserView>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _conf;

    public LoginUserHandler(IUserRepository repository, IMapper mapper, IConfiguration configuration)
    {
        _repository = repository;
        _mapper = mapper;
        _conf = configuration;

    }
    public async Task<LoginUserView> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUser(request.Email);

        if (user == null)
            throw new DbValidEx("User not found");
        if (user.Pass != request.Pass)
            throw new DbValidEx("Pass incorrect");
        if (user.Status == false)
            throw new DbValidEx("Email not confirm yet");

        var result =   _mapper.Map<LoginUserView>(user);


        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.Nickname)
        };


        result.Token = TokenGenerator(claims);

        return  result;
    }



    private string TokenGenerator(Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["Auth:Secret"]));
        var creds= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expry = DateTime.Now.AddDays(1);

        var token =  new JwtSecurityToken(claims: claims, expires: expry, signingCredentials: creds, notBefore: DateTime.Now);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}