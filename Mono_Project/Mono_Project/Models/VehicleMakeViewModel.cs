using System.ComponentModel.DataAnnotations;

namespace Mono_Project.Models
{

    public class VehicleMakeViewModel 
    {
        [Required(ErrorMessage = "You have to enter Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You have to enter Abbreviation")]
        public string Abrv { get; set; }
    }
}
