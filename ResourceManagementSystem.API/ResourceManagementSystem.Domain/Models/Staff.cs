using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Models
{
    // Creation of a Staff class which derives from the Identity server's user class
    public class Staff : IdentityUser
    {
        public string Name { get; set; }

        public DateTime HiredDate { get; set; }

    }

}
