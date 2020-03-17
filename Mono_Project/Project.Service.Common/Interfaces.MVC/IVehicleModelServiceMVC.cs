using Project.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common.Interfaces.MVC
{
    public interface IVehicleModelServiceMVC
    {
        public Task<bool> CreateAsync(VehicleModel vehicleModel);
        public Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData);
        public Task<bool> UpdateAsync(VehicleModel vehicleModel);
        public Task<bool> DeleteAsync(VehicleModel vehicleModel);
        public bool VehicleModelExists(int id);
        public Task<VehicleModel> FindAsync(int? id);
    }
}
