using Project.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        public Task<bool> CreateAsync(VehicleMake vehicleMake);
        public Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData);
        public Task<bool> UpdateAsync(VehicleMake vehicleMake);
        public Task<bool> DeleteAsync(VehicleMake vehicleMake);
        public bool VehicleMakeExists(int id);
        public Task<VehicleMake> FindAsync(int? id);
    }
}
