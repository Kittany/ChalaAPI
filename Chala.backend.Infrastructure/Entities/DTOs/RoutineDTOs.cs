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
            public Guid UserId { get; set; }
            public int TagId { get; set; }
            public long StartHour { get; set; }
            public bool Sunday { get; set; }
            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
            public bool IsActive { get; set; }

        }

        public class Edit : Create
        {
            public Guid Id { get; set; }
        }
    }
}
