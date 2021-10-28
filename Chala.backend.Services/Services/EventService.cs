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
        // GET ALL EVENTS <---- 
        public IEnumerable<Event> GetAllAsQueryable()
        {
            return _unitOfWork.Events.GetAllAsQueryable();
        }

        public Event GetById(Guid id)
        {
            return _unitOfWork.Events.GetById(id);
        }

      

    }
}
