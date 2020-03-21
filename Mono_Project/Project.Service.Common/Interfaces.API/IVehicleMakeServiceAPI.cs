using Project.Common;
using Project.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common.Interfaces.API
{
    public interface IVehicleMakeServiceAPI
    {
        public Task<bool> CreateAsync(VehicleMake vehicleMake);
        public Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null);
        public Task<bool> UpdateAsync(VehicleMake vehicleMake);
        public Task<bool> DeleteAsync(VehicleMake vehicleMake);
        public Task<bool> VehicleMakeExists(int id);
        public Task<VehicleMake> FindAsync(int? id);
    }
}
