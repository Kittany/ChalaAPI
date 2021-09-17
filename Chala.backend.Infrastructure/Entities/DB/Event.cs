using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class Event
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }
        public string Title { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

