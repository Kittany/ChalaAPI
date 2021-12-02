using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ForgotPasswordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ForgotPasswordTokens> GetAllAsQueryable()
        {
            return _unitOfWork.ForgotPasswordTokens.GetAllAsQueryable();
        }

        public bool GenerateForgotPasswordCode(string email)
        {
            var user = _unitOfWork.Users.SingleOrDefault(u => u.Email == email);

            if (user == null)
                return false;
            
            string code = StaticFunctions.RandomString(5);

            _unitOfWork.ForgotPasswordTokens.Add(new ForgotPasswordTokens { UserId = user.Id, Token = code,ValidUntil = DateTime.Now.AddDays(1) }
            );

            StaticFunctions.SendVerificationCode(email, user.FirstName, code);


            return _unitOfWork.Commit() > 0;
        }

        public bool CheckForgotPasswordCode(string code, Guid Id)
        {
            var user = _unitOfWork.Users.SingleOrDefault(u => u.Id == Id);
            if (user == null) return false;

            var res = _unitOfWork.ForgotPasswordTokens.SingleOrDefault(u => u.User.Id == user.Id && u.Token == code && u.ValidUntil > DateTime.Now);

            return res != null;

        }


    }
}
