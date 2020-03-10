using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Model.Model;
using System.Collections.Generic;

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
