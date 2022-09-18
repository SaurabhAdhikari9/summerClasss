using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.Shared
{
    // Creation of a Base entity having common attributes to all classes to be called by all the other classes
    public class Base
    {
        public DateTime CreatedAt { get; set; }
        
        public DateTime LastModifiedAt { get; set; }
    }
}
