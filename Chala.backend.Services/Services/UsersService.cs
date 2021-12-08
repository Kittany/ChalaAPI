using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using Chala.backend.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class UsersService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetAllAsQueryable()
        {
            return _unitOfWork.Users.GetAllAsQueryable();
        }

        public User GetById(Guid Id)
        {
            return _unitOfWork.Users.GetByIdIncluded(Id);
        }

        public Dictionary<string,string> Authorize(string email, string password)
        {
            var user = _unitOfWork.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (user == null)
                return new Dictionary<string, string>();

            var res =  BCrypt.Net.BCrypt.Verify(password, user.Password);


            if (res)
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("id", user.Id.ToString());
                dictionary.Add("token", StaticFunctions.GenerateJwtToken(user.Id));
                dictionary.Add("isVerified", user.IsVerified.ToString());

                return dictionary;
            }

            return new Dictionary<string, string>();
        }
        public bool Create(User user)
        {
            user.IsActive = true;
            user.CreateDate = DateTime.Now;

            //Hash the password using the Bcrypt library
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;


            _unitOfWork.Users.Add(user);


           var userCreated = _unitOfWork.Commit() > 0;

            if (userCreated)
            {
                string code = StaticFunctions.RandomString(5);
                VerificationCodes entity = new VerificationCodes();
                entity.UserId = user.Id;
                entity.VerificationCode = code;

                _unitOfWork.VerificationCodes.Add(entity);
                var createdVerificationCode = _unitOfWork.Commit() > 0;

                if (createdVerificationCode)
                {

                    Task.Run(() =>
                    {
                        StaticFunctions.SendVerificationCode(user.Email, user.FirstName, entity.VerificationCode);
                    });
                }


                return true;
            }
            return false;

        }

        public bool Delete(User user)
        {

            user.IsActive = false;
            _unitOfWork.Users.Update(user);
            return _unitOfWork.Commit() > 0;

        }

        public bool Edit(User oldUser, User newUser)
        {

            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;
            oldUser.Password = newUser.Password;

            _unitOfWork.Users.Update(oldUser);
            return _unitOfWork.Commit() > 0;

        }

        public bool ResetPassword(User user, string password)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password = passwordHash;
            _unitOfWork.Users.Update(user);
            return _unitOfWork.Commit() > 0;
        }
    }
}
