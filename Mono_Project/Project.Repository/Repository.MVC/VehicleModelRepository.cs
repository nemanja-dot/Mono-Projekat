using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.Repository.Common.Interfaces.MVC;
using Project.Model.Model;
using System.Linq;
using System.Threading.Tasks;
using Project.Common;

namespace Project.Service.Services
{
    public class VehicleModelRepository : IVehicleModelRepositoryMVC
    {
        private readonly ApplicationContext _applicationDbContext;

        public VehicleModelRepository(ApplicationContext applicationContext)
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
        public async Task<VehicleModel> FindAsync(int? id)
        {
            var vehicleMade = await _applicationDbContext.VehicleModel.Include(m => m.VehicleMake)
                .FirstOrDefaultAsync(m => m.Id == id);
            return vehicleMade;
        }
        public async Task<PagingDataList<VehicleModel>> GetAllAsync(PagingData pagingData)
        {
            var allVehicleMades = _applicationDbContext.VehicleModel.Include(m => m.VehicleMake).AsQueryable();

            if(pagingData.VehicleMakeId != null)
            {
                allVehicleMades = allVehicleMades.Where(m => m.VehicleMakeId == pagingData.VehicleMakeId);
            }

            if (!string.IsNullOrEmpty(pagingData.SearchString))
            {
                allVehicleMades = allVehicleMades.Where(s => s.Name.ToLower().Contains(pagingData.SearchString.ToLower())
                || s.Abrv.ToLower().Contains(pagingData.SearchString.ToLower()));
            }

            switch (pagingData.SortOrder)
            {
                case "name_desc":
                    allVehicleMades = allVehicleMades.OrderByDescending(s => s.Name);
                    break;
                default:
                    allVehicleMades = allVehicleMades.OrderBy(s => s.Name);
                    break;
            }

            var count = await allVehicleMades.CountAsync();
            var curentpage = pagingData.Page ?? 0;
            var take = pagingData.Count ?? 10;

            var result = await allVehicleMades.Skip(curentpage * take).Take(take).ToListAsync();

            return new PagingDataList<VehicleModel>(result, count, curentpage, take);
        }

        
        public async Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            _applicationDbContext.Update(vehicleModel);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public bool VehicleModelExists(int id)
        {
            return _applicationDbContext.VehicleModel.Any(e => e.Id == id);
        }

    }
}
