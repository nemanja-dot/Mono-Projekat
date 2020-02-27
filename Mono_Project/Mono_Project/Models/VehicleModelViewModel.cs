using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Models
{
    public class VehicleModelViewModel
    {
        
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
