using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandHelper.Data.InterfacesAndRepos;
using CommandHelper.DtoModels;
using CommandHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturer _repository;
        private readonly IMapper _mapper;
        public LecturersController(ILecturer repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/lecturers
        [HttpGet]
        public IEnumerable<Lecturer> GetAllCommands()
        {
            var lecturerItems = _repository.GetAllCommands();
            return lecturerItems;
        }
        //GET api/lecturers/{id}
        [HttpGet("{id}")]
        public Lecturer GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return commandItem;
            }
            return null;
        }
        //POST api/lecturers
        [HttpPost]
        public ActionResult<DtoLecturerCreate> CreateCommand(DtoLecturerCreate lecturerCreate)
        {
            var commandModel = _mapper.Map<Lecturer>(lecturerCreate);
            var result = _repository.CreateCommand(commandModel);
            if (result == 1)
            {
                return Ok(commandModel);
            }
            return BadRequest();
        }
        //DELETE api/lecturers/{id}
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