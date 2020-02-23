using Project.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
   public interface IVehicleModelService
    {
        public Task<bool> CreateAsync(VehicleModel vehicleModel);
        public Task<List<VehicleModel>> GetAllAsync(int page, int count);
        public Task<bool> UpdateAsync(VehicleModel vehicleModel);
        public Task<bool> DeleteAsync(VehicleModel vehicleModel);
    }
}
