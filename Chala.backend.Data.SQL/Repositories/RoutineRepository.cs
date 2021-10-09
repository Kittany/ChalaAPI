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
    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public RoutineRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<Routine> GetAllAsQueryable()
        {
            return _context.Routines.AsQueryable();
        }

        public Routine GetByIdIncluded(Guid Id)
        {
            return _context.Routines.Where(s => s.Id == Id).FirstOrDefault();
        }
    }
}
