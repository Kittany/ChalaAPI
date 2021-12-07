using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class Event
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public int TagId { get; set; }

        public string Title { get; set; }
        public int StartHour { get; set; }

        public DateTime Date { get; set; }
        public virtual User User { get; set; }

    }
}

