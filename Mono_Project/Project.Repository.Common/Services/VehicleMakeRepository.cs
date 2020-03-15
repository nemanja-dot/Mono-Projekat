using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository.Common.Services
{
    public class VehicleMakeRepository : RepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(ApplicationContext applicationContext )
            :base(applicationContext)
        {

        }
    }
}
