using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Domain.Models;
using ResourceManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Infrastructure.Repositories
{
    // Extends from the Repository Class based on the Product class and inherits the IProductRepository interface
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        // Declaring a field of ApplicationDbContext to access its properties
        private readonly ApplicationDbContext _dbContext;

        // Defining a constructor for dependency injection on DbContext
        // Passing the ApplicationDBContext object to the base class
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Method implementation for update of a product based on its interface
        public int Update(Product product)
        {
            // Retrieval of object from the database by examining the ID from the DB with the ID of the object passed
            var objectFromDB = _dbContext.Products.FirstOrDefault(c => c.ID == product.ID);

            if (objectFromDB != null)
            {
                // Assigning the properties of the object based on the parameterized object passed
                objectFromDB.Name = product.Name;
                objectFromDB.Quantity = product.Quantity;
                objectFromDB.Price = product.Price;
                objectFromDB.CategoryID = product.CategoryID;
                
                // Defining the last modified property to the current stage while it is updated
                objectFromDB.LastModifiedAt = DateTime.Now;

                // Returns 1 stating the object exists based on the ID entered
                return 1;
            }

            // Returns -1 when no any object are found based on the ID passed
            return -1;
        }
    }
}
