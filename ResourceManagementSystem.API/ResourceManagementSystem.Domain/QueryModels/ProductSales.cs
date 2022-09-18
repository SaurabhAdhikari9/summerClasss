using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.QueryModels
{
    // Creation of Sales class for all the Products transaction history and vending
    public class ProductSales
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public decimal Sales { get; set; }
    }
}
