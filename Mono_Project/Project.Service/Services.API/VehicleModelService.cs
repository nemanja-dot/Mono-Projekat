using Project.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Common.Interfaces.API;
using Project.Common;
using Microsoft.EntityFrameworkCore;
using Project.Repository.Common.Interfaces.API;
using System.Linq;

namespace Project.Service.Services.API
{
    public class VehicleModelService : IVehicleModelServiceAPI
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CreateAsync(VehicleModel vehicleModel)
        {
            return await _unitOfWork.VehicleModel.Create(vehicleModel);
        }

        public async Task<bool> DeleteAsync(VehicleModel vehicleModel)
        {
            return await _unitOfWork.VehicleModel.Delete(vehicleModel);
        }
        public async Task<VehicleModel> FindAsync(int? id)
        {
            return await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id);
        }
        public async Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData = null)
        {
            var allVehicleModel = _unitOfWork.VehicleModel.GetAllVehicleModel(pagingData);

            return await allVehicleModel;
        }

        public async Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            return await _unitOfWork.VehicleModel.Update(vehicleModel);
        }

        public async Task<bool> VehicleModelExists(int id)
        {
            return (await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id)) != null;
        }

    }
}

