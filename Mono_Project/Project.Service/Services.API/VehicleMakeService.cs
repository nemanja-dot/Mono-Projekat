using Microsoft.EntityFrameworkCore;
using Project.Common;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;
using Project.Service.Common.Interfaces.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services.API
{
    public class VehicleMakeService : IVehicleMakeServiceAPI
    {
        private readonly IUnitOfWork _unitOfWork;


        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(VehicleMake vehicleMake)
        {
            return await _unitOfWork.VehicleMake.Create(vehicleMake);
        }

        public async Task<bool> DeleteAsync(VehicleMake vehicleMake)
        {
            return await _unitOfWork.VehicleMake.Delete(vehicleMake);
        }

        public async Task<VehicleMake> FindAsync(int? id)
        {
            return await _unitOfWork.VehicleMake.FindByCondition(m => m.Id == id);
        }

        public async Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null)
        {
            var allVehicleMake = _unitOfWork.VehicleMake.GetAllVehicleMake(pagingData);

            return await allVehicleMake;
        }

        public async Task<bool> UpdateAsync(VehicleMake vehicleMake)
        {
            return await _unitOfWork.VehicleMake.Update(vehicleMake);
        }
        public async Task<bool> VehicleMakeExists(int id)
        {
            return (await _unitOfWork.VehicleMake.FindByCondition(m => m.Id == id)) != null;
        }
    }
}
