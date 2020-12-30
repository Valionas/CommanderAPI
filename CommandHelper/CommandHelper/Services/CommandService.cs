using AutoMapper;
using CommandHelper.Data;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Services
{
    public class CommandService
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandService(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
     
        public IEnumerable<CommandDtoRead> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            var res =  _mapper.Map<IEnumerable<CommandDtoRead>>(commandItems);
            return res;
        }
        //GET api/commands/{id}
      
        public CommandDtoRead GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return _mapper.Map<CommandDtoRead>(commandItem);
            }
            return null;
        }

        //POST api/commands
     
        public CommandDtoCreate CreateCommand(CommandDtoCreate commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return commandCreateDto;
            }
            return null;
        }

        //PUT api/commands/{id}
       
        public int UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return 0;
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return 1;
        }

        //PATCH api/commands/{id}
       
        public int PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return 0;
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch);
            

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return 1;
        }

        //DELETE api/commands/{id}
  
        public int DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return 0;
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return 1;
        }
    }
}
