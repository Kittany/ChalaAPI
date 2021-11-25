using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public bool IsFinished { get; set; }


        public virtual User User { get; set; }

    }
}