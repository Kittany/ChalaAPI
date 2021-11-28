using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public string Authorize(string email, string password)
        {
            var user = _unitOfWork.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (user == null)
                return "";

            var res =  BCrypt.Net.BCrypt.Verify(password, user.Password);


            if (res)
                return StaticFunctions.GenerateJwtToken(user.Id);

            return "";
        }
        public bool Create(User user)
        {
            user.IsActive = true;
            user.CreateDate = DateTime.Now;

            //Hash the password using the Bcrypt library
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;


            _unitOfWork.Users.Add(user);
            return _unitOfWork.Commit() > 0;
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
            oldUser.Birthdate = newUser.Birthdate;

            _unitOfWork.Users.Update(oldUser);
            return _unitOfWork.Commit() > 0;

        }


    }
}
