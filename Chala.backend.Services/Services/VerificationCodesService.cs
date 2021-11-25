using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class VerificationCodesService : IVerificationCodesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VerificationCodesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public VerificationCodes GetById(Guid id)
        {
            return _unitOfWork.VerificationCodes.GetById(id);
        }
        public bool GenerateVerificationCodeForEmail(string email)
        {
            string code = StaticFunctions.RandomString(5);
            var userData = _unitOfWork.Users.SingleOrDefault(u => u.Email == email);
            if (userData == null) return false;

            var user = _unitOfWork.VerificationCodes.SingleOrDefault(u => u.User.Email == email);
            if (user == null)
                _unitOfWork.VerificationCodes.Add(new VerificationCodes { User = _unitOfWork.Users.SingleOrDefault(u => u.Email == email), VerificationCode = code }
                );



            if (user != null) user.VerificationCode = code;


            StaticFunctions.SendVerificationCodeToUserEmail(email, userData.FirstName, code);

            return _unitOfWork.Commit() > 0;
        }

        public bool CheckVerificationCodeForEmail(string code, string email)
        {
            var user = _unitOfWork.Users.SingleOrDefault(u => u.Email == email);
            if (user == null) return false;

            var res = _unitOfWork.VerificationCodes.SingleOrDefault(u => u.User.Id == user.Id && u.VerificationCode == code );


            return res != null;

        }
    }
}
