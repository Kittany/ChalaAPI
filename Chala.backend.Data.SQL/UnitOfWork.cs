using Chala.backend.Core;
using Chala.backend.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Data.SQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChalaDbContext _context;
        public UnitOfWork(ChalaDbContext context)
        {
            this._context = context;
        }

        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IRoutineRepository _routineRepository;
        private ITodoTaskRepository _todoTaskRepository;
        private ITagRepository _tagRepository;
        private IForgotPasswordTokensRepository _forgotPasswordTokensRepository;




        public IUserRepository Users => _userRepository ??= new UserRepository(_context);


        public IEventRepository Events => _eventRepository ??= new EventRepository(_context);

        public IRoutineRepository Routines => _routineRepository ??= new RoutineRepository(_context);

        public ITodoTaskRepository TodoTasks => _todoTaskRepository ??= new TodoTaskRepository(_context);

        public ITagRepository Tags => _tagRepository ??= new TagRepository(_context);
        public IForgotPasswordTokensRepository ForgotPasswordTokens => _forgotPasswordTokensRepository ??= new ForgotPasswordTokensRepository(_context);


        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
