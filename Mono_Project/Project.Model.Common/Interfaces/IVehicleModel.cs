using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common.Interfaces
{
    public interface IVehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
