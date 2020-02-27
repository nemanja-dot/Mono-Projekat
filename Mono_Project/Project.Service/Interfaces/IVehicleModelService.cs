using Project.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
   public interface IVehicleModelService
    {
        public Task<bool> CreateAsync(VehicleModel vehicleModel);
        public Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData);
        public Task<bool> UpdateAsync(VehicleModel vehicleModel);
        public Task<bool> DeleteAsync(VehicleModel vehicleModel);
        public bool VehicleModelExists(int id);
        public Task<VehicleModel> FindAsync(int? id);

    
    }
}
