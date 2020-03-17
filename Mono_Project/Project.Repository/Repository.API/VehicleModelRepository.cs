using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces;
using Project.Repository.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.API
{
    public class VehicleModelRepository : RepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
