using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class Routine
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }
        public string Title { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public virtual User User { get; set; }
        public virtual Tag Tag { get; set; }

    }
}