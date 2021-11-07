using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IRepositories
{
    public interface IForgotPasswordTokensRepository : IRepository<ForgotPasswordTokens>
    {
        IEnumerable<ForgotPasswordTokens> GetAllAsQueryable();
        ForgotPasswordTokens GetByIdIncluded(Guid id);
    }
}
