using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DTOs
{
    public class RoutineDTOs
    {
        public class Create
        {
            public string Title { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int StartHour { get; set; }
            public int EndHour { get; set; }
            public bool Sunday { get; set; }
            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
        }



        public class Edit : Create
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public Guid TagId { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
