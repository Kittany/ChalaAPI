using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DTOs;
using Chala.backend.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly IRoutineService _routineService;

        public SchedulesController(IUserService userService, IEventService eventService, IRoutineService routineService)
        {
            _userService = userService;
            _eventService = eventService;
            _routineService = routineService;
        }

        [HttpPost]
        [Route("GetByDate")]
        public IActionResult GetByDate([FromBody] ScheduleDTOs dto)
        {
            try
            {


                var user = _userService.GetById(dto.UserId);

                if (user == null)
                    return BadRequest("User doesn't exist.");


                var userRoutines = _routineService.GetAllAsQueryable().Where(routine => routine.UserId == dto.UserId && routine.IsActive);

                switch ((int)dto.Date.DayOfWeek)
                {
                    case 0:
                        userRoutines = userRoutines.Where(x => x.Sunday == true);
                        break;
                    case 1:
                        userRoutines = userRoutines.Where(x => x.Monday == true);
                        break;
                    case 2:
                        userRoutines = userRoutines.Where(x => x.Tuesday == true);
                        break;
                    case 3:
                        userRoutines = userRoutines.Where(x => x.Wednesday == true);
                        break;
                    case 4:
                        userRoutines = userRoutines.Where(x => x.Thursday == true);
                        break;
                    case 5:
                        userRoutines = userRoutines.Where(x => x.Friday == true);
                        break;
                    case 6:
                        userRoutines = userRoutines.Where(x => x.Saturday == true);
                        break;
                }

                var response = new List<object>();

                double ticks;
                TimeSpan time;

                foreach (var routine in userRoutines)
                {
                    ticks = double.Parse(routine.StartHour);
                    time = TimeSpan.FromMilliseconds(ticks);

                    response.Add(new
                    {
                        id = routine.Id,
                        type = Enums.DataTypes.Routine,
                        tagId = routine.TagId,
                        title = routine.Title,
                        startHour = routine.StartHour,
                        timeInMinutes = ((new DateTime(1970, 1, 1) + time).Hour * 60) + (new DateTime(1970, 1, 1) + time).Minute
                    });
                    ;
                }

                var selectedDate = dto.Date.ToString("yyyy-MM-dd");

                var userEvents = _eventService.GetAllAsQueryable().Where(u => u.UserId == dto.UserId && u.Date.ToString("yyyy-MM-dd") == selectedDate);



                foreach (var tempEvent in userEvents)
                {
                    ticks = double.Parse(tempEvent.StartHour);
                    time = TimeSpan.FromMilliseconds(ticks);

                    response.Add(new
                    {
                        id = tempEvent.Id,
                        type = Enums.DataTypes.Event,
                        tagId = tempEvent.TagId,
                        title = tempEvent.Title,
                        startHour = tempEvent.StartHour,
                        timeInMinutes = ((new DateTime(1970, 1, 1) + time).Hour * 60) + (new DateTime(1970, 1, 1) + time).Minute
                    });
                    ;

                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong...");
            }

        }
    }
}
