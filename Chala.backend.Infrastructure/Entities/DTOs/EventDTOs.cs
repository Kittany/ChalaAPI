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
        }

        public class Edit : Create
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public int StartHour { get; set; }
            public int EndHour { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
