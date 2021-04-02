using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.Repositories;

namespace Tasks.UOW
{
    public class TaskUnitOfWork : ITaskUnitOfWork
    {
        private readonly TasksDBContext _context;

        public ITaskRepository Tasks { get; private set; }

        public TaskUnitOfWork(TasksDBContext context)
        {
            _context = context;
            Tasks = new TaskRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
           return  _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
