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



        public bool Create(Routine routine)
        {
            _unitOfWork.Routines.Add(routine);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(Routine routine)
        {
            _unitOfWork.Routines.Remove(routine);
            return _unitOfWork.Commit() > 0;

        }

        public bool Edit(Routine oldRoutine, Routine newRoutine)
        {
            oldRoutine.Title = newRoutine.Title;
            oldRoutine.StartHour = newRoutine.StartHour;
            oldRoutine.Sunday = newRoutine.Sunday;
            oldRoutine.Monday = newRoutine.Monday;
            oldRoutine.Tuesday = newRoutine.Tuesday;
            oldRoutine.Wednesday = newRoutine.Wednesday;
            oldRoutine.Thursday = newRoutine.Thursday;
            oldRoutine.Friday = newRoutine.Friday;
            oldRoutine.Saturday = newRoutine.Saturday;
            oldRoutine.IsActive = newRoutine.IsActive;
            oldRoutine.TagId = newRoutine.TagId;
            _unitOfWork.Routines.Update(oldRoutine);
            return _unitOfWork.Commit() > 0;
        }

    }
}
