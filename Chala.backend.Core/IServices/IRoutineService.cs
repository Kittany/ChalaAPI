using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IServices
{
    public interface IRoutineService
    {
        IEnumerable<Routine> GetAllAsQueryable();
        Routine GetById(Guid id);

    }
}
