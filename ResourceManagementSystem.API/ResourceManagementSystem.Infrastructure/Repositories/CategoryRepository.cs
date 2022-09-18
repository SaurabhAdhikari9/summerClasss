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
    // Extends from the Repository Class based on the Category class and inherits the ICategoryRepository interface
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // Declaring a field of ApplicationDbContext to access its properties
        private readonly ApplicationDbContext _dbContext;

        // Defining a constructor for dependency injection on DbContext
        // Passing the ApplicationDBContext object to the base class
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(Category category)
        {
            // Retrieval of object from the database by examining the ID from the DB with the ID of the object passed
            var objectFromDB = _dbContext.Categories.FirstOrDefault(c => c.ID == category.ID);

            if (objectFromDB != null)
            {
                // Assigning the properties of the object based on the parameterized object passed
                objectFromDB.Title = category.Title;

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
