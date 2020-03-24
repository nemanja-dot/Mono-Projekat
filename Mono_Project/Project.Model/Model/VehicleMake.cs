using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Model.Common.Interfaces;

namespace Project.Model.Model
{
   public class VehicleMake : IVehicleMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        // [ForeignKey("VehicleMakeId")]
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
