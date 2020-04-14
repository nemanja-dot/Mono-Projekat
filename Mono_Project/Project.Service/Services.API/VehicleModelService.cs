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
            return await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id).SingleOrDefaultAsync();
        }
        public async Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData = null)
        {
            var allVehicleModel = _unitOfWork.VehicleModel.FindAll();


            if (pagingData == null)
            {
                var allResults = await allVehicleModel.ToListAsync();
                return new PagingDataList<VehicleModel>(allResults, allResults.Count, 0, allResults.Count);
            }

            if (!string.IsNullOrEmpty(pagingData.SearchString))
            {
                allVehicleModel = allVehicleModel.Where(s => s.Name.ToLower().Contains(pagingData.SearchString.ToLower())
                                       || s.Abrv.ToLower().Contains(pagingData.SearchString.ToLower()));
            }

            switch (pagingData.SortOrder)
            {
                case "isAscending":
                    allVehicleModel = allVehicleModel.OrderBy(s => s.Name);
                    break;
                default:
                    allVehicleModel = allVehicleModel.OrderByDescending(s => s.Name);
                    break;
            }

            var count = await allVehicleModel.CountAsync();

            var currentPage = pagingData.Page ?? 0;
            var take = pagingData.Count ?? 10;

            var results = await allVehicleModel.Skip(currentPage * take).Take(take).ToListAsync();

            return new PagingDataList<VehicleModel>(results, count, currentPage, take);
        }

        public async Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            return await _unitOfWork.VehicleModel.Update(vehicleModel);
        }

        public async Task<bool> VehicleModelExists(int id)
        {
            return (await _unitOfWork.VehicleModel.FindByCondition(m => m.Id == id).SingleOrDefaultAsync()) != null;
        }

    }
}

