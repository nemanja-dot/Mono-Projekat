using Project.Service.Interfaces;
using Project.Model.Model;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }


        public async Task<bool> CreateAsync(VehicleModel vehicleModel)
        {
            return await _vehicleModelRepository.CreateAsync(vehicleModel);
        }

        public async Task<bool> DeleteAsync(VehicleModel vehicleModel)
        {
            return await _vehicleModelRepository.DeleteAsync(vehicleModel);
        }
        public async Task<VehicleModel> FindAsync(int? id)
        {
            return await _vehicleModelRepository.FindAsync(id);
        }
        public async Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData)
        {
            return await _vehicleModelRepository.GetAllAsync(pagingData);
        }
        
        public async Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            return await _vehicleModelRepository.UpdateAsync(vehicleModel);
        }

        public bool VehicleModelExists(int id)
        {
            return _vehicleModelRepository.VehicleModelExists(id);
        }

    }
}
