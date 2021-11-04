using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class ForgotPasswordTokens
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
