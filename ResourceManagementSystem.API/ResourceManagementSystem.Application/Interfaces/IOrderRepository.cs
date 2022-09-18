using ResourceManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.Interfaces
{
    // Inheriting the main IRepository interface defined for the order class
    public interface IOrderRepository : IRepository<Order>
    {
        decimal Transaction(string ID, int Quantity);
    }
}
