using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandHelper.Data;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using CommandHelper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        private readonly CommandService _cmdService;

        public CommandsController(CommandService cmdService,ICommanderRepo repository,IMapper mapper)
        {
            _cmdService = cmdService;
            _repository = repository;
            _mapper = mapper;

        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandDtoRead>> GetAllCommands()
        {
            return Ok(_cmdService.GetAllCommands());
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandDtoRead> GetCommandById(int id)
        {
            var res = _cmdService.GetCommandById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandDtoRead> CreateCommand(CommandDtoCreate commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return Ok(commandModel);
            }
            return BadRequest();
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _cmdService.DeleteCommand(id);
            if (commandModelFromRepo == 0)
            {
                return NotFound();
            }
            _cmdService.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}