using Chala.backend.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }
        IEventRepository Events { get; }
        IRoutineRepository Routines { get; }
        ITodoTaskRepository TodoTasks { get; }
        ITagRepository Tags { get; }
        IForgotPasswordTokensRepository ForgotPasswordTokens { get; }
        IVerificationCodesRepository VerificationCodes { get; }

        int Commit();
    }
}
