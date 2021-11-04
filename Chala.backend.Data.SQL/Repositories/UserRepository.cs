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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public UserRepository(ChalaDbContext context) : base(context)
        {

        }
        public IEnumerable<User> GetAllAsQueryable()
        {
            return _context.Users.AsQueryable();
        }

        public User GetByIdIncluded(Guid Id)
        {
            return _context.Users.Where(s => s.Id == Id).FirstOrDefault();
        }

    }
}
