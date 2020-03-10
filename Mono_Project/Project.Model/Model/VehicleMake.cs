using System.ComponentModel.DataAnnotations;
using Project.Model.Interfaces;

namespace Project.Model.Model
{
   public class VehicleMake : IVehicleMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
