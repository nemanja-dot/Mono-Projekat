using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Interface
{
    interface IVehicleModelViewModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public List<SelectListItem> VehicleMakes { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
