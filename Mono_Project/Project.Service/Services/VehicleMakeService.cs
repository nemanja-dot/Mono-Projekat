using Microsoft.EntityFrameworkCore;
using Project.Service.Context;
using Project.Service.Interfaces;
using Project.Service.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly ApplicationContext _applicationDbContext;

        public VehicleMakeService(ApplicationContext applicationContext)
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

        public async Task<List<VehicleMake>> GetAllAsync(int page, int count)
        {
            return await _applicationDbContext.VehicleMake.Skip(page * count).Take(count).ToListAsync();
        }

        public Task<bool> UpdateAsync(VehicleMake vehicleMake)
        {
            throw new System.NotImplementedException();
        }
    }
}
