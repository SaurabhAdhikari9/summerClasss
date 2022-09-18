using ResourceManagementSystem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Models
{
    // Creation of a Product class having its individual property and extending from the Base class
    public class Product : Base
    {
        [Key]
        public string ID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category? Category {get; set;}
        
        public virtual List<OrderLine>? OrderLines { get; set; }

    }
}
