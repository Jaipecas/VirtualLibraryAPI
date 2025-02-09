using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.Application.Persistence
{
    public interface IVirtualLibraryUnitOfWork : IDisposable
    {
        Task<int> Save();
    }
}
