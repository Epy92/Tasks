using System.Collections.Generic;
using Tasks.ViewModel;

namespace Tasks.Services
{
    public interface ITaskService
    {
        Models.Task GetById(int id);
        IEnumerable<Models.Task> GetAll();
        public void Add(Models.Task task);
        public void Update(Models.Task task, int id);
        public void Remove(int id);
        IEnumerable<Models.Task> GetOverdueTasks();
        IEnumerable<Models.Task> GetPendingTasks();
        IEnumerable<Models.Task> GetInProgressTasks();
        IEnumerable<Models.Task> GetWorkingTasks();
        StatisticsViewModel GetStatistics();
    }
}
