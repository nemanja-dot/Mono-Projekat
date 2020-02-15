using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Model
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
