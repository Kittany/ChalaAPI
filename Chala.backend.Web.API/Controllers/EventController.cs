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

        [HttpGet]
        [Route("GetEventsByDate")]
        public IActionResult GetEventsByDate([FromBody] DateTime dateTime)
        {
            var events = _eventService.GetEventsByDate(dateTime);
            if (events != null)
                return Ok(events);
            else
                return BadRequest("Empty events");
        }

        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent([FromBody] EventDTOs.Create dto)
        {
            try
            {
                var eventt = _mapper.Map<Event>(dto);
                var res = _eventService.Create(eventt);

                if (res)
                    return Ok("Event has been created.");

                return BadRequest("Failed to create an event.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create an event.");
            }
        }


        [HttpPost]
        [Route("EditEventById/{Id}")]
        public IActionResult EditEventById(Guid Id, [FromBody] EventDTOs.Edit dto)
        {
            // Check if prevEvent != null <->
            var prevEvent = _eventService.GetById(Id);

            var newEdittedEvent = _mapper.Map<Event>(dto);

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
