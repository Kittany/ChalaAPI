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

        //public IEnumerable<bool> GetWeekStatus(Guid Id)
        //{
        //    var routine = _unitOfWork.Routines.GetWeekStatus(Id);
        //    // if condition?
        //    return routine;
        //}
    }
}
