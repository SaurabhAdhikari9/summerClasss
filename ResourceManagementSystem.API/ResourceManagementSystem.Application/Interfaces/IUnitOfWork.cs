using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.Interfaces
{
    // Creation of a single interface to bind up all of the defined interfaces and its repositories
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository Staff { get; }

        ICategoryRepository Category { get; }
        
        IProductRepository Product { get; }
        
        IOrderRepository Order { get; }

        void Save();
    }
}
