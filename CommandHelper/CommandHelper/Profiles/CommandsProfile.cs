using AutoMapper;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Profiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandDtoRead>();
            CreateMap<CommandDtoCreate, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
            CreateMap<Platform, PlatformDto>().ReverseMap();
            CreateMap<DtoTutorialCreate, Tutorial>();
            CreateMap<DtoLecturerCreate, Lecturer>();
            CreateMap<EventDTO, Event>();

        }
    }
}
