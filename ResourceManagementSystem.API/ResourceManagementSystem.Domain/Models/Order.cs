using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Models
{
    // Creation of an Order class for defining the properties included in individual orders only
    public class Order
    {
        [Key]
        public string ID { get; set; }
        
        public DateTime OrderedDate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }

        public string StaffID { get; set; }

        [ForeignKey("StaffID")]
        public Staff? Staff { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; } 
    }
}
