﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Domain.QueryModels
{
    // Creation of a Sales class to identify sales produced by each of the staffs respectively
    public class StaffSales
    {
        public string Name { get; set; }
        
        public decimal Sales { get; set; }
    }
}
