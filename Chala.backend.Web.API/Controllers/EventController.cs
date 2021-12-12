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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IMapper mapper, IUserService userService)
        {
            _eventService = eventService;
            _mapper = mapper;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllEvents/{Id}")]
        public IActionResult GetAllEvents(Guid Id)
        {

            var user = _userService.GetAllAsQueryable().Where(x => x.Id == Id).FirstOrDefault();

            if (user == null)
                return BadRequest("User does not exist.");

            var events = _eventService.GetAllAsQueryable().Where(x => x.UserId == user.Id);


            List<object> response = new List<object>();

            DateTime today = new DateTime();
            foreach (var item in events)
            {
                if (item.Date > today)
                {
                    response.Add(new
                    {
                        id = item.Id,
                        tagId = item.TagId,
                        title = item.Title,
                        startHour = item.StartHour,
                        date = item.Date.ToShortDateString()
                    });
                }
            }

            return Ok(response);

        }




        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [Authorize]
        [HttpPost]
        [Route("EditEventById")]
        public IActionResult EditEventById([FromBody] EventDTOs.Edit dto)
        {

            var prevEvent = _eventService.GetById(dto.Id);

            if (prevEvent == null)
                return BadRequest("Event does not exist.");

            var newEdittedEvent = _mapper.Map<Event>(dto);

            if (_eventService.Edit(prevEvent, newEdittedEvent))
                return Ok("Event Has been edited.");
            else
                return BadRequest("Failed to edit the event");
        }

        [Authorize]
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
