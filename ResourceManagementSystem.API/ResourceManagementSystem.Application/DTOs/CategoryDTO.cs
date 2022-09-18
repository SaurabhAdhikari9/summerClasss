using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    // Creation of a Category DTO in order to display only the required attributes of Category class
    public class CategoryDTO
    {
        public string ID { get; set; }

        public string Title { get; set; }
    }
}
