using Chala.backend.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chala.backend.Core.IServices
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetAllAsQueryable();
        TodoTask GetById(Guid id);
        bool Create(TodoTask todoTask);
        bool Edit(TodoTask oldTodoTask, TodoTask newTodoTask);
        bool Delete(TodoTask todoTask);
    }
}
