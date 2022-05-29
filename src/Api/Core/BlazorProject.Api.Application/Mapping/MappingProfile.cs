using AutoMapper;
using BlazorProject.Api.Domain.Models;
using BlazorProject.Common.Models.CommandModel;
using BlazorProject.Common.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Api.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserView>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<Entry, CreateEntryCommand>().ReverseMap();
        }
    }
}
