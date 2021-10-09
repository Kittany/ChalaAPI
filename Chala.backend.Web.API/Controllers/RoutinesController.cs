using AutoMapper;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
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

    }
}
