using ResourceManagementSystem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Models
{
    // Creation of a Category class having its individual property and extending from the Base class
    public class Category : Base
    {
        [Key]
        public string ID { get; set; }

        public string Title { get; set; }
    }
}
