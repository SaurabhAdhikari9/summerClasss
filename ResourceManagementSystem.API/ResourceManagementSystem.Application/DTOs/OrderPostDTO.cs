using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    public class OrderPostDTO
    {
        public string ID { get; set; }

        public string StaffID { get; set; }

        public List<OrderLinePostDTO> OrderLines { get; set; }
    }
}
