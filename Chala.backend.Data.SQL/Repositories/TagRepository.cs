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
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private ChalaDbContext _context { get { return Context as ChalaDbContext; } }
        public TagRepository(ChalaDbContext context) : base(context)
        {

        }

        public IEnumerable<Tag> GetAllAsQueryable()
        {
            return _context.Tags.AsQueryable();
        }

        public Tag GetByIdIncluded(Guid Id)
        {
            return _context.Tags.Where(s => s.Id == Id).FirstOrDefault();
        }

    }
}
