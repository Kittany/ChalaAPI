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
        private readonly IUserService _userService;

        public TodoTasksController(IMapper mapper, ITodoTaskService todoTaskService, IUserService userService)
        {
            _mapper = mapper;
            _todoTaskService = todoTaskService;
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllTodoTasks/{Id}")]
        public IActionResult GetAllTodoTask(Guid Id)
        {


            var user = _userService.GetById(Id);

            if (user == null)
                return BadRequest("User does not exist.");

            var todoTasks = _todoTaskService.GetAllAsQueryable().Where(x => x.UserId == user.Id);


            List<object> response = new List<object>();

            foreach(var task in todoTasks)
            {
                response.Add(new
                {
                    id = task.Id,
                    title = task.Title,
                    isFinished = task.IsFinished
                });
            }    

            return Ok(response);
        }



        [HttpGet]
        [Route("GetTodoTasksById/{Id}")]
        public IActionResult GetTodoTasksById(Guid Id)
        {
            var todoTasks = _todoTaskService.GetById(Id);
            if (todoTasks != null)
                return Ok(todoTasks);

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
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpPost]
        [Route("EditTodoTask")]
        public IActionResult EditTodoTask([FromBody] TodoTaskDTOs.Edit dto)
        {
            try
            {
                var prevTodoTask = _todoTaskService.GetById(dto.Id);
                var newEdittedTodoTask = _mapper.Map<TodoTask>(dto);

                if (_todoTaskService.Edit(prevTodoTask, newEdittedTodoTask))
                    return Ok("TodoTask has been edited.");

                return BadRequest("Failed to edit the todoTask.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to edit the todoTask.");
            }

        }
        [HttpPost]
        [Route("DeleteTodoTask/{Id}")]
        public IActionResult DeleteTodoTask(Guid Id)
        {
            try
            {
                var todoTask = _todoTaskService.GetById(Id);

                if (_todoTaskService.Delete(todoTask))
                    return Ok("TodoTask has been deleted.");

                return BadRequest("Failed to delete the todoTask.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the todoTask.");
            }

        }
    }
}
