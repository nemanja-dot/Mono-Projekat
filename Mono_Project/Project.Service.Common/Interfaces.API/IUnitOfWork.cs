using Project.Repository.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Common.Interfaces.MVC
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository VehicleMake { get; }

        IVehicleModelRepository VehicleModel { get; }

        void Save();
    }
}
