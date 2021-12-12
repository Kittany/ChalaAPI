using AutoMapper;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using Chala.backend.Web.API.Authentication;
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
    public class RoutinesController : ControllerBase
    {
        // Add Create Routine action.
        private readonly IMapper _mapper;
        private readonly IRoutineService _routineService;
        private readonly IUserService _userService;

        public RoutinesController(IMapper mapper, IRoutineService routineService, IUserService userService)
        {
            _mapper = mapper;
            _routineService = routineService;
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllRoutines/{Id}")]
        public IActionResult GetAllRoutines(Guid Id)
        {

            var user = _userService.GetById(Id);

            if (user == null)
                return BadRequest("User does not exist.");


            var routines = _routineService.GetAllAsQueryable().Where(x => x.UserId == user.Id);


            List<object> response = new List<object>();

            foreach (var item in routines)
            {
                response.Add(new
                {
                    id = item.Id,
                    tagId = item.TagId,
                    title = item.Title,
                    startHour = item.StartHour,
                    sunday = item.Sunday,
                    monday = item.Monday,
                    tuesday = item.Tuesday,
                    wednesday = item.Wednesday,
                    thursday = item.Thursday,
                    friday = item.Friday,
                    saturday = item.Saturday,
                    isActive = item.IsActive
                   
                });
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetRoutineById/{Id}")]
        public IActionResult GetRoutineById(Guid Id)
        {
            var routine = _routineService.GetById(Id);
            if (routine != null)
                return Ok(routine);
            else
                return BadRequest("Routine not found");
        }
        [Authorize]
        [HttpPost]
        [Route("CreateRoutine")]
        public IActionResult CreateRoutine([FromBody] RoutineDTOs.Create dto)
        {
            try
            {
                var routine = _mapper.Map<Routine>(dto);
                var res = _routineService.Create(routine);

                if (res)
                    return Ok("Routine has been created.");

                return BadRequest("Failed to create a routine.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create a rotuine.");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("EditRoutineById")]
        public IActionResult EditRoutineById([FromBody] RoutineDTOs.Edit dto)
        {


            var prevRoutine = _routineService.GetById(dto.Id);

            if (prevRoutine == null)
                return BadRequest("Routine does not exist.");



            var newEdittedRoutine = _mapper.Map<Routine>(dto);

            if (_routineService.Edit(prevRoutine, newEdittedRoutine))
                return Ok("Routine Has been edited.");
            else
                return BadRequest("Failed to edit the routine");
        }

        [Authorize]
        [HttpPost]
        [Route("DeleteRoutineById/{Id}")]
        public IActionResult DeleteRoutineById(Guid Id)
        {
            try
            {
                var routine = _routineService.GetById(Id);

                if (_routineService.Delete(routine))
                    return Ok("Routine has been deleted.");

                return BadRequest("Failed to delete the Routine.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the Routine.");
            }

        }
    }
}
