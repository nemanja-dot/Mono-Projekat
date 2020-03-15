using Project.Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository VehicleMake { get; }

        IVehicleModelRepository VehicleModel { get; }

        void Save();
    }
}
