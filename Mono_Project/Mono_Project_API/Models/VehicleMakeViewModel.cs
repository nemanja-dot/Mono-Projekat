﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project_API.Models
{
    public class VehicleMakeViewModel
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Abrv { get; set; }

        public int ModelCount { get; set; }
    }
}
