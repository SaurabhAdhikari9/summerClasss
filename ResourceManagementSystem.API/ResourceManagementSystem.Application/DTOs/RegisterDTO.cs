using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Application.DTOs
{
    // Creation of a Register DTO for the required attributes to be entered for registration purposes
    public class RegisterDTO
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HiredDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
