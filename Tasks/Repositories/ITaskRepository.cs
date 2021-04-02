using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.Repositories
{
    public interface ITaskRepository: IRepository<Task>
    {
        IEnumerable<Task> GetOverdueTasks();
        IEnumerable<Task> GetPendingTasks();
        IEnumerable<Task> GetInProgressTasks();
        IEnumerable<Task> GetWorkingTasks();
        void Update(Task task, int id);
    }
}
