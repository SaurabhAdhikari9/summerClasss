using ResourceManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.Interfaces
{
    // Inheriting the main IRepository interface defined for the category class
    public interface ICategoryRepository : IRepository<Category>
    {
        int Update(Category category);
    }
}
