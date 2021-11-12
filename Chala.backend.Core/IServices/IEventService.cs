using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IServices
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllAsQueryable();
        Event GetById(Guid id);
        IEnumerable<Event> GetEventsByDate(DateTime dateTime);
        public bool Edit(Event oldEvent, Event newEvent);
        public bool Delete(Event e);
        public bool Create(Event e);
    }
}
