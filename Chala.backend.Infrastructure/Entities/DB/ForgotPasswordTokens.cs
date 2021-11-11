using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class ForgotPasswordTokens
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ValidUntil { get; set; }


        public virtual User User { get; set; }

    }
}
