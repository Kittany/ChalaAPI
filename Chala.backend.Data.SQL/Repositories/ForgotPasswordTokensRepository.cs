using Chala.backend.Core.IRepositories;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Data.SQL.Repositories
{
    public class ForgotPasswordTokensRepository : Repository<ForgotPasswordTokens>, IForgotPasswordTokensRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public ForgotPasswordTokensRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<ForgotPasswordTokens> GetAllAsQueryable()
        {
            return _context.ForgotPasswordTokens.AsQueryable();
        }

        public ForgotPasswordTokens GetByIdIncluded(Guid Id)
        {
            return _context.ForgotPasswordTokens.Where(s => s.Id == Id).FirstOrDefault();
        }
    }
}
