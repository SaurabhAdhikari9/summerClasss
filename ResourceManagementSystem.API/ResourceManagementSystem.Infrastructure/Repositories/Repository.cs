using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Application.Interfaces;
using ResourceManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Infrastructure.Repositories
{
    // Implementation of Interface on a generic class to be extended by any of its child classes
    public class Repository<T> : IRepository<T> where T : class
    {
        // Declaring a field of ApplicationDbContext to access all of its DbSets
        private readonly ApplicationDbContext _dbContext;

        // Declaring of a dbSet of a particular class
        public DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            // Dependency injection for DbContext
            _dbContext = dbContext;

            // Creating a DBSet of a particular class which extends the Repository class
            _dbSet = _dbContext.Set<T>();
        }

        // Method implementation to add an object of a class to the database
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Method implementation to delete an object of a class from the database
        public int Delete(string id)
        {
            var obj = _dbSet.Find(id);

            if(obj != null)
            {
                _dbSet.Remove(obj);

                // Returns 1 when an object is found based on the ID entered
                return 1;
            }

            // Returns -1 when an object is not found based on the ID entered
            return -1;
        }

        // Method implementation to retrieve an object of a class from the database
        public T Get(string id)
        {
            return _dbSet.Find(id);
        }

        // Function to retrieve all the data from the database in a listed format
        public List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            // Initialization of IQueryable list for query purposes
            IQueryable<T> query = _dbSet;

            // For a not null filter, to include the filtered data in the list
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // For a not null orderBy, to include the ordered data in the list
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            // For a not null includeProperties, to include other inclusive data in the list
            if (includeProperties != null)
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }

            // Returning the query in form of a list based on all the conditions passed
            return query.ToList();
        }
    }
}
