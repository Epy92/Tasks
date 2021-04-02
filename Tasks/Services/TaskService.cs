using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.UOW;
using Tasks.ViewModel;

namespace Tasks.Services
{
    public class TaskService : ITaskService
    {
        protected readonly ITaskUnitOfWork _taskUnitOfWork;
        protected readonly ILogger<TaskService> _logger;

        public TaskService(ITaskUnitOfWork taskUnitOfWork, ILogger<TaskService> logger)
        {
            _taskUnitOfWork = taskUnitOfWork;
            _logger = logger;
        }

        public void Add(Models.Task task)
        {
            try
            {
                _taskUnitOfWork.Tasks.Add(task);
                _taskUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Task could not be saved. Please try again!");
            }
        }

        public void Update(Models.Task task, int id)
        {
            try
            {
                _taskUnitOfWork.Tasks.Update(task, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IEnumerable<Models.Task> GetAll()
        {
            return _taskUnitOfWork.Tasks.GetAll();
        }

        public Models.Task GetById(int id)
        {
            return _taskUnitOfWork.Tasks.GetById(id);
        }

        public IEnumerable<Models.Task> GetInProgressTasks()
        {
           return _taskUnitOfWork.Tasks.GetInProgressTasks();
        }

        public IEnumerable<Models.Task> GetOverdueTasks()
        {
            return _taskUnitOfWork.Tasks.GetOverdueTasks();
        }

        public IEnumerable<Models.Task> GetPendingTasks()
        {
            return _taskUnitOfWork.Tasks.GetPendingTasks();
        }

        public IEnumerable<Models.Task> GetWorkingTasks()
        {
            return _taskUnitOfWork.Tasks.GetWorkingTasks();
        }

        public void Remove(int id)
        {
            var task = _taskUnitOfWork.Tasks.GetById(id);
            if (task != null)
            {
                _taskUnitOfWork.Tasks.Remove(task);
                _taskUnitOfWork.SaveChanges();
            }
            else 
            {
                throw new Exception($"Task with ID {id} does not exist.");
            }
        }

        public StatisticsViewModel GetStatistics()
        {
            return new StatisticsViewModel()
            {
                InProgress = _taskUnitOfWork.Tasks.GetInProgressTasks().Count(),
                Pending = _taskUnitOfWork.Tasks.GetPendingTasks().Count(),
                Overdue = _taskUnitOfWork.Tasks.GetOverdueTasks().Count()
            };
        }
    }
}
