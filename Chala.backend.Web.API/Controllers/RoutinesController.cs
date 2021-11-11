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
    public class RoutinesController : ControllerBase
    {
        // Add Create Routine action.
        private readonly IMapper _mapper;
        private readonly IRoutineService _routineService;

        public RoutinesController(IMapper mapper, IRoutineService routineService)
        {
            _routineService = routineService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllRoutines")]
        public IActionResult GetAllRoutines()
        {
            var routines = _routineService.GetAllAsQueryable().ToList();
            if (routines != null)
                return Ok(routines);
            else
                return BadRequest("Empty routines");
        }
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


        [HttpPost]
        [Route("EditRoutineById/{Id}")]
        public IActionResult EditRoutineById(Guid Id, [FromBody] RoutineDTOs.Edit newRoutine)
        {
            // Add Routine != null <->
            var prevRoutine = _routineService.GetById(Id);
            var newEdittedRoutine = _mapper.Map<Routine>(newRoutine);

            if (_routineService.Edit(prevRoutine, newEdittedRoutine))
                return Ok("Routine Has been edited.");
            else
                return BadRequest("Failed to edit the routine");
        }


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
