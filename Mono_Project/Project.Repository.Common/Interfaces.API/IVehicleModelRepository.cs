using Project.Common;
using Project.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.Interfaces.API
{
    public interface IVehicleModelRepository : IRepositoryBase<VehicleModel>
    {
        public Task<PagingDataList<VehicleModel>> GetAllVehicleModel(PagingData pagingData = null);
    }
}
