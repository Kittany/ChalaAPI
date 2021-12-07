using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DTOs
{
    public class EventDTOs
    {
        public class Create
        {
            public string Title { get; set; }
            public Guid UserId { get; set; }
            public int TagId { get; set; }
            public int StartHour { get; set; }
            public DateTime Date { get; set; }
        }

        public class Edit : Create
        {
            public Guid Id { get; set; }

        }
    }
}
