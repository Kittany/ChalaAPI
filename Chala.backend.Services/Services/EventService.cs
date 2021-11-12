using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Event> GetAllAsQueryable()
        {
            return _unitOfWork.Events.GetAllAsQueryable();
        }

        public Event GetById(Guid id)
        {
            return _unitOfWork.Events.GetById(id);
        }

        public IEnumerable<Event> GetEventsByDate(DateTime dateTime)
        {
            return _unitOfWork.Events.Where(e => e.Date.Day == dateTime.Day);
        }


        public bool Create(Event e)
        {
            _unitOfWork.Events.Add(e);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(Event e)
        {
            _unitOfWork.Events.Remove(e);
            return _unitOfWork.Commit() > 0;

        }

        public bool Edit(Event oldEvent, Event newEvent)
        {
            oldEvent.Title = newEvent.Title;
            oldEvent.StartHour = newEvent.StartHour;
            oldEvent.EndHour = newEvent.EndHour;
            oldEvent.Date = newEvent.Date;

            _unitOfWork.Events.Update(oldEvent);
            return _unitOfWork.Commit() > 0;
        }
    }
}
