using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Infrastructure.Repositories
{
    // Implementation of its defined interface and following its functionality
    public class UnitOfWork : IUnitOfWork
    {
        // Defining a field for the ApplicationDbContext to be injected in the constructor
        private readonly ApplicationDbContext _dbContext;

        // Injecting the DbContext on the constructor
        // Passing the same DbContext on each of the constructor of every repository 
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Category = new CategoryRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
            Order = new OrderRepository(_dbContext);
            Staff = new StaffRepository(_dbContext);
        }

        public IStaffRepository Staff { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public IOrderRepository Order { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
