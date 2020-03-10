using Project.Model.Model;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeRepository
    {
        public Task<bool> CreateAsync(VehicleMake vehicleMake);
        public Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null);
        public Task<bool> UpdateAsync(VehicleMake vehicleMake);
        public Task<bool> DeleteAsync(VehicleMake vehicleMake);
        public bool VehicleMakeExists(int id);
        public Task<VehicleMake> FindAsync(int? id);
    }
}
