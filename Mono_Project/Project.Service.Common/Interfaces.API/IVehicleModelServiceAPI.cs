using Project.Common;
using Project.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common.Interfaces.API
{
    public interface IVehicleModelServiceAPI
    {
        public Task<bool> CreateAsync(VehicleModel vehicleModel);
        public Task<IEnumerable<VehicleModel>> GetAllAsync(PagingData pagingData = null);
        public Task<bool> UpdateAsync(VehicleModel vehicleModel);
        public Task<bool> DeleteAsync(VehicleModel vehicleModel);
        Task<bool> VehicleModelExists(int id);
        public Task<VehicleModel> FindAsync(int? id);
    }
}
