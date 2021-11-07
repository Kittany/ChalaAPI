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
    public class ForgotPasswordTokensService : IForgotPasswordTokensService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ForgotPasswordTokensService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET ALL EVENTS <---- 
        public IEnumerable<ForgotPasswordTokens> GetAllAsQueryable()
        {
            return _unitOfWork.ForgotPasswordTokens.GetAllAsQueryable();
        }

        public ForgotPasswordTokens GetById(Guid id)
        {
            return _unitOfWork.ForgotPasswordTokens.GetById(id);
        }

    }
}
