using Chala.backend.Core.IServices;
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
    // Add get the events of a specific user
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("GetAllEvents")]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.GetAllAsQueryable().ToList();
            if (events != null)
                return Ok(events);
            else
                return BadRequest("Empty events");
        }
        [HttpGet]
        [Route("GetEventById/{Id}")]
        public IActionResult GetEventById(Guid Id)
        {
            var _event = _eventService.GetById(Id);
            if (_event != null)
                return Ok(_event);
            else
                return BadRequest("Invalid Id / Empty event");
        }

    }
}
