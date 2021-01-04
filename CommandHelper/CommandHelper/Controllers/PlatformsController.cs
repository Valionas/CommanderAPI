using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandHelper.Data.InterfacesAndRepos;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatform _repository;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatform repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/events
        [HttpGet]
        public IEnumerable<Platform> GetAllCommands()
        {
            var platforms = _repository.GetAllCommands();
            return platforms;
        }
        //GET api/events/{id}
        [HttpGet("{id}")]
        public Platform GetCommandById(int id)
        {
            var singlePlatform = _repository.GetCommandById(id);
            if (singlePlatform != null)
            {
                return singlePlatform;
            }
            return null;
        }
        //POST api/events
        [HttpPost]
        public ActionResult<PlatformDto> CreateCommand(PlatformDto pltCreate)
        {
            var commandModel = _mapper.Map<Platform>(pltCreate);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return Ok(commandModel);
            }
            return BadRequest();
        }
        //DELETE api/events/{id}
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