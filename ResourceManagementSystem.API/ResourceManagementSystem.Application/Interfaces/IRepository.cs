using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.Interfaces
{
    // Objects of any particular class are not explicitly defined in a generic repository
    // The following repository can then be inherited by any other interfaces to implement its functionalities
    public interface IRepository<T> where T : class
    {
        // Defining a method of a class which returns an object of that particular class when supplied with an ID
        T Get(string id);

        // Defining a method to extract all the values of a particular class based on a condition passed as its parameter
        List<T> GetAll(
            Expression<Func<T, bool>> filter = null,                        // Retrieval of data based on certain filter
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,       // Retrieval of data to order it in a particular field
            string includeProperties = null                                 // Retrieval of extra data from the external foreign source
            );

        // Defining a method to add an object of a particular class to the database
        void Add(T entity);

        // Defining a method to delete an object of a particular class from the database
        int Delete(string ID);
    }
}
