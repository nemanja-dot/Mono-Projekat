﻿using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.Service.Interfaces;
using Project.Model.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Project.Service.Services
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly ApplicationContext _applicationDbContext;

        public VehicleMakeRepository(ApplicationContext applicationContext)
        {
            _applicationDbContext = applicationContext;
        }


        public async Task<bool> CreateAsync(VehicleMake vehicleMake)
        {
            _applicationDbContext.VehicleMake.Add(vehicleMake);
            _applicationDbContext.Entry(vehicleMake).State = EntityState.Added;
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(VehicleMake vehicleMake)
        {
            _applicationDbContext.VehicleMake.Remove(vehicleMake);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<VehicleMake> FindAsync(int? id)
        {
            var vehicleMake = await _applicationDbContext.VehicleMake
                .FirstOrDefaultAsync(m => m.Id == id);
            return vehicleMake;
        }

        public async Task<PagingDataList<VehicleMake>> GetAllAsync(PagingData pagingData = null)
        {
            var allVehicleMakes = _applicationDbContext.VehicleMake.AsQueryable();

            if (pagingData == null)
            {
                var allResults = await allVehicleMakes.ToListAsync();
                return new PagingDataList<VehicleMake>(allResults, allResults.Count, 0, allResults.Count);
            }

            if (!string.IsNullOrEmpty(pagingData.SearchString))
            {
                allVehicleMakes = allVehicleMakes.Where(s => s.Name.ToLower().Contains(pagingData.SearchString.ToLower())
                                       || s.Abrv.ToLower().Contains(pagingData.SearchString.ToLower()));
            }

            switch (pagingData.SortOrder)
            {
                case "name_desc":
                    allVehicleMakes = allVehicleMakes.OrderByDescending(s => s.Name);
                    break;
                default:
                    allVehicleMakes = allVehicleMakes.OrderBy(s => s.Name);
                    break;
            }

            var count = await allVehicleMakes.CountAsync();

            var currentPage = pagingData.Page ??= 0;
            var take = pagingData.Count ??= 10;

            var results = await allVehicleMakes.Skip(currentPage * take).Take(take).ToListAsync();

            return new PagingDataList<VehicleMake>(results, count, currentPage, take);
        }

        public async Task<bool> UpdateAsync(VehicleMake vehicleMake)
        {
            _applicationDbContext.Update(vehicleMake);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
        public bool VehicleMakeExists(int id)
        {
            return _applicationDbContext.VehicleMake.Any(e => e.Id == id);
        }
    }
}