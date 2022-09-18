using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    // Creation of a Product DTO in order to add only the required attributes of Product class while inserting or updating its data
    public class ProductUpsertDTO
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string CategoryID { get; set; }
    }
}
