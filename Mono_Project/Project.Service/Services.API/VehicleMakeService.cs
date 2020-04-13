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
            return await _unitOfWork.VehicleMake.FindByCondition(m => m.Id == id).SingleOrDefaultAsync();
        }

        public async Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null)
        {
            var allVehicleMake = _unitOfWork.VehicleMake.FindAll();


            if (pagingData == null)
            {
                var allResults = await allVehicleMake.ToListAsync();
                return new PagingDataList<VehicleMake>(allResults, allResults.Count, 0, allResults.Count);
            }

            if (!string.IsNullOrEmpty(pagingData.SearchString))
            {
                allVehicleMake = allVehicleMake.Where(s => s.Name.ToLower().Contains(pagingData.SearchString.ToLower())
                                       || s.Abrv.ToLower().Contains(pagingData.SearchString.ToLower()));
            }

            switch (pagingData.SortOrder)
            {
                case "isAscending":
                    allVehicleMake = allVehicleMake.OrderBy(s => s.Name);
                    break;
                default:
                    allVehicleMake = allVehicleMake.OrderByDescending(s => s.Name);
                    break;
            }

            var count = await allVehicleMake.CountAsync();

            var currentPage = pagingData.Page ?? 0;
            var take = pagingData.Count ?? 10;

            var results = await allVehicleMake.Skip(currentPage * take).Take(take).ToListAsync();
            
            return new PagingDataList<VehicleMake>(results, count, currentPage, take);
        }

        public async Task<bool> UpdateAsync(VehicleMake vehicleMake)
        {
            return await _unitOfWork.VehicleMake.Update(vehicleMake);
        }
        public async Task<bool> VehicleMakeExists(int id)
        {
            return (await _unitOfWork.VehicleMake.FindByCondition(m => m.Id == id).SingleOrDefaultAsync()) != null;
        }
    }
}
