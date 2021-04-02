using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Repositories;

namespace Tasks.UOW
{
    public interface ITaskUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
