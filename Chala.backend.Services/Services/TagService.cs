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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Tag> GetAllAsQueryable()
        {
            return _unitOfWork.Tags.GetAllAsQueryable();
        }

        public Tag GetById(Guid Id)
        {
            return _unitOfWork.Tags.GetById(Id);
        }

    }
}
