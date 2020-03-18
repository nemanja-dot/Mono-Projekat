using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.Common.Interfaces.API
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository VehicleMake { get; }

        IVehicleModelRepository VehicleModel { get; }

        void Save();
    }
}
