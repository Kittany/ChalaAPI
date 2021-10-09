using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DTOs
{
    public class TodoTaskDTOs
    {
        public class Create
        {
            public Guid UserId { get; set; }
            public string Title { get; set; }
        }
        public class Edit
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public string Title { get; set; }
        }
    }
}
