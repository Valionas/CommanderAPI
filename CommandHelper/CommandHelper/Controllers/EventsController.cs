using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandHelper.Data.InterfacesAndRepos;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventcs _repository;
        private readonly IMapper _mapper;
        public EventsController(IEventcs repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/events
        [HttpGet]
        public IEnumerable<Event> GetAllCommands()
        {
            var events = _repository.GetAllCommands();
            return events;
        }
        //GET api/events/{id}
        [HttpGet("{id}")]
        public Event GetCommandById(int id)
        {
            var singleEvent = _repository.GetCommandById(id);
            if (singleEvent != null)
            {
                return singleEvent;
            }
            return null;
        }
        //POST api/events
        [HttpPost]
        public ActionResult<EventDTO> CreateCommand(EventDTO eventCreate)
        {
            var commandModel = _mapper.Map<Event>(eventCreate);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return Ok(commandModel);
            }
            _repository.SaveChanges();
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
