using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Dtos;
using TestApi.Models;

namespace TestApi.Profiles
{
    public class CommandsProfiles : Profile
    {
        public CommandsProfiles()
        {
            // Source --> target

            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }

    }
}
