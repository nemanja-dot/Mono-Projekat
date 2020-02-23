using Microsoft.EntityFrameworkCore;
using Project.Service.Context;
using Project.Service.Interfaces;
using Project.Service.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly ApplicationContext _applicationDbContext;

        public VehicleModelService(ApplicationContext applicationContext)
        {
            _applicationDbContext = applicationContext;
        }


        public async Task<bool> CreateAsync(VehicleModel vehicleModel)
        {
            _applicationDbContext.VehicleModel.Add(vehicleModel);
            _applicationDbContext.Entry(vehicleModel).State = EntityState.Added;
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(VehicleModel vehicleModel)
        {
            _applicationDbContext.VehicleModel.Remove(vehicleModel);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<VehicleModel>> GetAllAsync(int page, int count)
        {
            return await _applicationDbContext.VehicleModel.Skip(page * count).Take(count).ToListAsync();
        }

        public Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
