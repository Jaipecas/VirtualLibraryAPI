using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.Application.Persistence.Repositories;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork
    {
        IProducts Products { get; }
        Task<int> SaveChanges();
    }
}
