using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using TestApi.Dtos;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        
        //get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int Id)
        {

            var command = _repository.GetCommandById(Id);
            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }

        // post api/commands
        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
           
        }
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int Id, CommandUpdateDto commandUpdateDto)
        {
            var commandModel = _repository.GetCommandById(Id);
            if (commandModel == null)
            {
                return NotFound(); 
            }
            _mapper.Map(commandUpdateDto, commandModel);
            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CommandReadDto> DeleteCommand(int Id)
        {

            var command = _repository.GetCommandById(Id);
            if (command == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(command);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
