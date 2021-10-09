using AutoMapper;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITodoTaskService _todoTaskService;

        public TodoTasksController(IMapper mapper, ITodoTaskService todoTaskService)
        {
            _mapper = mapper;
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        [Route("GetAllTodoTask/{Id}")]
        public IActionResult GetAllTodoTask(Guid Id)
        {
            var todoTasks = _todoTaskService.GetAllAsQueryable();
            if (todoTasks != null)
                return Ok(todoTasks);
            else
                return BadRequest("Empty TodoTasks");
        }
        [HttpGet]
        [Route("GetTodoTasksById/{Id}")]
        public IActionResult GetTodoTasksById(Guid Id)
        {
            var todoTasks = _todoTaskService.GetById(Id);
            if (todoTasks != null)
                return Ok(todoTasks);
            else
                return BadRequest("todoTask not found");
        }
        [HttpPost]
        [Route("CreateTodoTask")]
        public IActionResult CreateTodoTask([FromBody] TodoTaskDTOs.Create dto)
        {
            try
            {
                var todoTask = _mapper.Map<TodoTask>(dto);

                var res = _todoTaskService.Create(todoTask);

                if (res)
                    return Ok("TodoTask has been created.");

                return BadRequest("Failed to create a todoTask.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create a todoTask.");
            }

        }
    }
}
