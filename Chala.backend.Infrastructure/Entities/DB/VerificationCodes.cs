using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Infrastructure.Entities.DB
{
    public class VerificationCodes
    {
        public Guid Id { get; set; }

        public string VerifiedCode { get; set; }

        public virtual User User { get; set; }
    }
}
