using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllAsQueryable();
        Event GetByIdIncluded(Guid id);
    }
}
