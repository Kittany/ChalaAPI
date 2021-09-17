using Chala.backend.Infrastructure.Entities.DB;
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
        string Authorize(string email, string password);
        bool Create(User user);
        bool Edit(User oldUser, User newUser);
        bool Delete(User user);


    }
}
