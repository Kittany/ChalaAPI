using Chala.backend.Core;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Services.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TodoTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Create(TodoTask todoTask)
        {
            _unitOfWork.TodoTasks.Add(todoTask);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(TodoTask todoTask)
        {
            _unitOfWork.TodoTasks.Remove(todoTask);
            return _unitOfWork.Commit() > 0;

        }

        public bool Edit(TodoTask oldTodoTask, TodoTask newTodoTask)
        {
            oldTodoTask.Title = newTodoTask.Title;
            _unitOfWork.TodoTasks.Update(oldTodoTask);
            return _unitOfWork.Commit() > 0;
        }

        public IEnumerable<TodoTask> GetAllAsQueryable()
        {
            return _unitOfWork.TodoTasks.GetAllAsQueryable();
        }

        public TodoTask GetById(Guid Id)
        {
            return _unitOfWork.TodoTasks.GetById(Id);
        }
    }
}
