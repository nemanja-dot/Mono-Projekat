using Project.Service.Interfaces;
using System.Threading.Tasks;
using Project.Model.Model;

namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<bool> CreateAsync(VehicleMake vehicleMake)
        {
            return await _vehicleMakeRepository.CreateAsync(vehicleMake);
        }

        public async Task<bool> DeleteAsync(VehicleMake vehicleMake)
        {
            return await _vehicleMakeRepository.DeleteAsync(vehicleMake);
        }

        public async Task<VehicleMake> FindAsync(int? id)
        {
            return await _vehicleMakeRepository.FindAsync(id);
        }

        public async Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null)
        {
            return await _vehicleMakeRepository.GetAllAsync(pagingData);
        }

        public async Task<bool> UpdateAsync(VehicleMake vehicleMake)
        {
            return await _vehicleMakeRepository.UpdateAsync(vehicleMake);
        }
        public bool VehicleMakeExists(int id)
        {
            return _vehicleMakeRepository.VehicleMakeExists(id);
        }
    }
}
