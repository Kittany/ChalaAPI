using Chala.backend.Core.IRepositories;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Data.SQL.Repositories
{
    public class VerificationCodesRepository: Repository<VerificationCodes>, IVerificationCodesRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public VerificationCodesRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<VerificationCodes> GetAllAsQueryable()
        {
            return _context.VerificationCodes.AsQueryable();
        }

        public VerificationCodes GetByIdIncluded(Guid Id)
        {
            return _context.VerificationCodes.Where(s => s.Id == Id).FirstOrDefault();
        }
    }
}
