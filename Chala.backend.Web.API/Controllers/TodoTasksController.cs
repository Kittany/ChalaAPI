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
        [Route("GetAllTodoTask")]
        public IActionResult GetAllTodoTask()
        {
            var todoTasks = _todoTaskService.GetAllAsQueryable();
            if (todoTasks != null)
                return Ok(todoTasks);

            return BadRequest("Empty TodoTasks");
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
            catch (Exception)
            {
                return BadRequest("Failed to create a todoTask.");
            }

        }
        [HttpPost]
        [Route("EditTodoTask/{Id}")]
        public IActionResult EditTodoTask(Guid Id, [FromBody] TodoTaskDTOs.Edit newTodoTask)
        {
            try
            {
                bool res = false;
                var todoLists = _todoTaskService.GetAllAsQueryable();
                foreach (TodoTask todoTask in todoLists)
                {
                    if (todoTask.Id == Id)
                    {
                        var newEdittedTodoTask = _mapper.Map<TodoTask>(newTodoTask);
                        res = _todoTaskService.Edit(todoTask, newEdittedTodoTask);
                        break;
                    }
                }
                if (res)
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
                bool res = false;
                var todoTasks = _todoTaskService.GetAllAsQueryable();
                foreach (TodoTask todoTask in todoTasks)
                {
                    if (todoTask.Id == Id)
                    {
                        res = _todoTaskService.Delete(todoTask);
                        break;
                    }
                }

                if (res)
                    return Ok("TodoTask has been deleted.");

                return BadRequest("Failed to delete the todoTask.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the todoTask.");
            }

        }

        //public IActionResult DeleteTodoTask([FromBody] TodoTaskDTOs.Create dto)
        //{
        //    try
        //    {
        //        var todoTask = _mapper.Map<TodoTask>(dto);

        //        var res = _todoTaskService.Delete(todoTask);

        //        if (res)
        //            return Ok("TodoTask has been created.");

        //        return BadRequest("Failed to create a todoTask.");
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Failed to create a todoTask.");
        //    }

        //}
    }
}
