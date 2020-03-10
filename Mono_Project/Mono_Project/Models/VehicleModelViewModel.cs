using Microsoft.AspNetCore.Mvc.Rendering;
using Mono_Project.Interface;
using Project.Model.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mono_Project.Models
{

    public class VehicleModelViewModel : IVehicleModelViewModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Vehicle Make")]
        public int VehicleMakeId { get; set; }
        [Display(Name = "Vehicle Make")]
        public VehicleMake VehicleMake { get; set; }
        public List<SelectListItem> VehicleMakes { get; set; }
        [Required(ErrorMessage = "You have to enter Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You have to enter Abbreviation")]
        public string Abrv { get; set; }
    }
}
