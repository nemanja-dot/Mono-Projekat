using Mono_Project.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mono_Project.Models
{

    public class VehicleMakeViewModel : IVehicleMakeViewModel
    {
        [Required(ErrorMessage = "You have to enter Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You have to enter Abbreviation")]
        public string Abrv { get; set; }
    }
}
