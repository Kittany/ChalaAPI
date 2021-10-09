using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DTOs
{
    public class UserDTOs
    {
        public class Create
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }

        public class Edit : Create
        {
            public Guid Id { get; set; }
            public bool IsActive { get; set; }
        }

    }
}
