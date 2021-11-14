using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IRepositories
{
    public interface IVerificationCodesRepository : IRepository<VerificationCodes>
    {
        // Maybe remove this later
        IEnumerable<VerificationCodes> GetAllAsQueryable();
        VerificationCodes GetByIdIncluded(Guid id);
    }
}
