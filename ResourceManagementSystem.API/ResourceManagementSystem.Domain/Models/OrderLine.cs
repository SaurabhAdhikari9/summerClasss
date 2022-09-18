using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Models
{
    // Creation of an Order Line class to track down ordering of each products on individual orders
    public class OrderLine
    {
        public string OrderID { get; set; }
        
        public string ProductID { get; set; }
        
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal LineTotal { get; set; }

        [ForeignKey("OrderID")]
        public Order? Order { get; set; }
        
        [ForeignKey("ProductID")]
        public Product? Product{ get; set; }
    }
}
