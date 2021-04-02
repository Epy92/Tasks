using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Models;

namespace Tasks.Repositories
{
    public class TaskRepository: RepositoryBase<Models.Task>, ITaskRepository
    {
        public TaskRepository(TasksDBContext context) : base(context)
        {

        }

        public IEnumerable<Models.Task> GetInProgressTasks()
        {
            return _context.Tasks.Where(x => x.Status == (int)ViewModel.TaskStatus.InProgress).ToList();
        }

        public IEnumerable<Models.Task> GetOverdueTasks()
        {
            return GetAllWorkingTasks().Where(x=> x.EndDate.HasValue && x.EndDate < DateTime.UtcNow).ToList();
        }

        public IEnumerable<Models.Task> GetPendingTasks()
        {
            return _context.Tasks.Where(x => x.Status == (int)ViewModel.TaskStatus.Pending).ToList();
        }

        public IEnumerable<Models.Task> GetWorkingTasks()
        {
            return GetAllWorkingTasks().ToList();
        }

        public void Update(Models.Task task, int id)
        {
            var existentTask = _context.Tasks.FirstOrDefault(x => x.Id == id);
            if (existentTask != null)
            {
                existentTask.StartDate = task.StartDate;
                existentTask.EndDate = task.EndDate;
                existentTask.TaskName = task.TaskName;
                existentTask.Status = task.Status;
                _context.Update(existentTask);                
            }
            else 
            {
                throw new Exception($"Task with ID {id} does not exist!");
            }
        }

        private IQueryable<Models.Task> GetAllWorkingTasks() 
        {
            return _context.Tasks.Where(x => x.Status == (int)ViewModel.TaskStatus.Pending || x.Status == (int)ViewModel.TaskStatus.InProgress);
        }
    }
}
