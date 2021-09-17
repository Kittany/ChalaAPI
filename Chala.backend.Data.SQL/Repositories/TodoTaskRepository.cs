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
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public TodoTaskRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<TodoTask> GetAllAsQueryable()
        {
            return _context.TodoTasks.AsQueryable();
        }

        public TodoTask GetByIdIncluded(Guid Id)
        {
            return _context.TodoTasks.Where(s => s.Id == Id).FirstOrDefault();
        }

    }
}
