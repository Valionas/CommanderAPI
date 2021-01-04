using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandHelper.Data;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialsController : ControllerBase
    {
        private readonly ITutorialRepo _repository;
        private readonly IMapper _mapper;
        public TutorialsController(ITutorialRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/tutorials
        [HttpGet]
        public IEnumerable<Tutorial> GetAllCommands()
        {
            var tutorialItems = _repository.GetAllCommands();          
            return tutorialItems;
        }
        //GET api/tutorials/{id}
        [HttpGet("{id}")]
        public Tutorial GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return commandItem;
            }
            return null;
        }
        //POST api/tutorials
        [HttpPost]
        public ActionResult<DtoTutorialCreate> CreateCommand(DtoTutorialCreate tutorialCreate)
        {
            var commandModel = _mapper.Map<Tutorial>(tutorialCreate);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return Ok(commandModel);
            }
            return BadRequest();
        }
        //DELETE api/tutorial/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}