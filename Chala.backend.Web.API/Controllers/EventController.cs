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
    // Add get the events of a specific user
    public class EventController : ControllerBase
    {
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
        public IActionResult EditEventById([FromBody] EventDTOs.Edit newEvent, Guid Id)
        {
            var res = false;
            var events = _eventService.GetAllAsQueryable();
            foreach (Event e in events)
            {
                if (e.Id == Id)
                {
                    var newEdittedEvent = _mapper.Map<Event>(newEvent);
                    res = _eventService.Edit(e, newEdittedEvent);
                    break;
                }
            }
            if (res)
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
                bool res = false;
                var events = _eventService.GetAllAsQueryable();
                foreach (Event e in events)
                {
                    if (e.Id == Id)
                    {
                        res = _eventService.Delete(e);
                        break;
                    }
                }
                if (res)
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
