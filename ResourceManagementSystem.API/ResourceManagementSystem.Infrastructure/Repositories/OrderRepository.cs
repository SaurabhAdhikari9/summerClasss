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
    // Extends from the Repository Class based on the Order class and inherits the IOrderRepository interface
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        // Declaring a field of ApplicationDbContext to access its properties
        private readonly ApplicationDbContext _dbContext;

        // Defining a constructor for dependency injection on DbContext
        // Passing the ApplicationDBContext object to the base class
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Method implementation for update of a product's stock quantity based on its interface
        public decimal Transaction(string ID, int Quantity)
        {
            // Retrieval of object from the database by examining the ID from the DB with the ID of the object passed
            var objectFromDB = _dbContext.Products.Find(ID);

            if (objectFromDB != null)
            {
                if(objectFromDB.Quantity >= Quantity)
                {
                    // Assigning the line total for each of products being ordered
                    var lineTotal = Quantity * objectFromDB.Price;

                    // Assigning the change in quantity of the object based on the parameterized object passed
                    objectFromDB.Quantity -= Quantity;

                    // Returns the total line total for a single products order
                    return lineTotal;
                }
                else
                {
                    // Returns -1 stating that the quantity ordered is more than the total quantity of the product
                    return -1;
                }
            }
            // Returns -1 when no any object are found based on the ID passed
            return -1;
        }
    }
}
