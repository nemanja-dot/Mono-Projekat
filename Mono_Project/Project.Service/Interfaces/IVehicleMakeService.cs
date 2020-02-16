using Project.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        public Task<bool> CreateAsync(VehicleMake vehicleMake);
        public Task<List<VehicleMake>> GetAllAsync(int page, int count);
        public Task<bool> UpdateAsync(VehicleMake vehicleMake);
        public Task<bool> DeleteAsync(VehicleMake vehicleMake);
    }
}
