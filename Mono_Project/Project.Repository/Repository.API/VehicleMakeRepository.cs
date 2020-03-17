using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces;
using Project.Repository.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Text;


namespace Project.Repository.API
{
    public class VehicleMakeRepository : RepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
