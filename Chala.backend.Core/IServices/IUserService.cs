using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IServices
{
    public interface IUserService 
    {
        IEnumerable<User> GetAllAsQueryable();
        User GetById(Guid id);
        Dictionary<string,string> Authorize(string email, string password);
        bool Create(User user);
        bool Edit(User oldUser, User newUser);
        bool Delete(User user);
        bool ResetPassword(User user, string password);

    }
}
