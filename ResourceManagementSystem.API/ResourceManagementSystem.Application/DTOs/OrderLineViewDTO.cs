using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    public class OrderLineViewDTO
    {
        public string OrderID { get; set; }

        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal LineTotal { get; set; }

        public ProductViewDTO Product { get; set; }
    }
}
