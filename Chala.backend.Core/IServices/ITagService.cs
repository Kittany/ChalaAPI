using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IServices
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAllAsQueryable();
        Tag GetTagById(Guid id);

        //public Tuple<bool> GetWeekStatus(Guid id)
        //{
        //    //_context.Routines.AsQueryable().Select()
        //    return  _context.Routines
        //    .Where(x => x.UserId == id)
        //    .Select(x => new { x.Sunday, x.Monday, x.Tuesday, x.Wednesday, x.Thursday, x.Friday,x.Saturday });
        //}
        int GetStartHour(Guid id);
        int GetEndHour(Guid id);
    }
}
