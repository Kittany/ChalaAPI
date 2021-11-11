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
    public class EventController : ControllerBase
    {
        // Add CreateEvent action.
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IMapper mapper, IEventService eventService)
        {
            _eventService = eventService;
            _mapper = mapper;
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


        [HttpPost]
        [Route("EditEventById/{Id}")]
        public IActionResult EditEventById(Guid Id, [FromBody] EventDTOs.Edit newEvent)
        {
            // Check if prevEvent != null <->
            var prevEvent = _eventService.GetById(Id);

            var newEdittedEvent = _mapper.Map<Event>(newEvent);

            if (_eventService.Edit(prevEvent, newEdittedEvent))
                return Ok("Event Has been edited.");
            else
                return BadRequest("Failed to edit the event");
        }


        [HttpPost]
        [Route("DeleteEventById/{Id}")]
        public IActionResult DeleteEventById(Guid Id)
        {
            try
            {
                var _event = _eventService.GetById(Id);
                if (_eventService.Delete(_event))
                    return Ok("Event has been deleted.");

                return BadRequest("Failed to delete the Event.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the Event.");
            }

        }

    }
}
