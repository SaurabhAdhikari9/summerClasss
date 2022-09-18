using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    public class OrderViewDTO
    {
        public string ID { get; set; }

        public DateTime OrderedDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string StaffID { get; set; }

        public StaffDTO Staff { get; set; }

        public List<OrderLineViewDTO> OrderLines { get; set; }

    }
}
