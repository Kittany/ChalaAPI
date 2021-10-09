using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoutineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Routine GetById(Guid Id)
        {
            return _unitOfWork.Routines.GetById(Id);
        }

        public IEnumerable<Routine> GetAllAsQueryable()
        {
            return _unitOfWork.Routines.GetAllAsQueryable();
        }



        public int GetEndHour(Guid id)
        {
            return _unitOfWork.Routines.GetById(id).StartHour;
        }

        public int GetStartHour(Guid id)
        {
            return _unitOfWork.Routines.GetById(id).EndHour;
        }

        //public bool[] GetWeekStatus(Guid Id)
        //{
        //    var routine = _unitOfWork.Routines.GetById(Id);

        //    bool[] temp = new bool[7];
        //    int index = 0;
        //    var booleanWeekObject = _unitOfWork.Routines
        //     .Where(x => x.UserId == Id)
        //     .Select(x => new  { x.Sunday, x.Monday, x.Tuesday, x.Wednesday, x.Thursday, x.Friday, x.Saturday })
        //     .ToList();
        //    foreach (var day in booleanWeekObject)
        //    {
        //        temp[index] = day;
        //    }
        //    // if condition?
        //    return routine;
        //}

        //    public IEnumerable<bool> GetWeekStatus(Guid id)
        //    {
        //        //_context.Routines.AsQueryable().Select()
        //        var dataset = _context.Routines
        //.Where(x => x.UserId == id)
        //.Select(x => new { x.Sunday, x.Monday, x.Tuesday, x.Wednesday, x.Thursday, x.Friday, x.Saturday }).ToList();
        //    }

    }
}
