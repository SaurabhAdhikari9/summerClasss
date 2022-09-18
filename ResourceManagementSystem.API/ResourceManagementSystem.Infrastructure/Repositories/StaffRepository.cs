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
    // Extends from the Repository Class based on the Staff class and inherits the IStaffRepository interface
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StaffRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
