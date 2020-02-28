using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Models
{
    public class VehicleModelViewModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Vehicle Make")]
        public int VehicleMakeId { get; set; }
        [Display(Name = "Vehicle Make")]
        public VehicleMake VehicleMake { get; set; }
        public List<SelectListItem> VehicleMakes { get; set; }
        [Required(ErrorMessage = "You have to enter name!")]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
