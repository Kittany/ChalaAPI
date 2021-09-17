using Chala.backend.Data.SQL;
using Chala.backend.Data.SQL.Repositories;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IRepositories
{
    public class EventRepository : Repository<Event>,IEventRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public EventRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<Event> GetAllAsQueryable()
        {
            return _context.Events.AsQueryable();
        }

        public Event GetByIdIncluded(Guid Id)
        {
            return _context.Events.Where(s => s.Id == Id).FirstOrDefault();
        }

    }
}
