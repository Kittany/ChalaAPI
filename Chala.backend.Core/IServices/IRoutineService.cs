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
        public bool Edit(Routine oldRoutine, Routine newRoutine);
        public bool Delete(Routine routine);
        public bool Create(Routine routine);

    }
}
