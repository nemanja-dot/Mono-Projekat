using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Service.Interfaces;

namespace Project.Service.Model
{
    public class VehicleModel : IVehicleModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
