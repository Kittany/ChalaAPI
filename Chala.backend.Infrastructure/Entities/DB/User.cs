using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TodoTask> Tasks { get; set; }
        public virtual ICollection<Routine> Routines { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
