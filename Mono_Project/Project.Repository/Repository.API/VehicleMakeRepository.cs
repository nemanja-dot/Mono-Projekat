using Microsoft.EntityFrameworkCore;
using Project.Common;
using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository.API
{
    public class VehicleMakeRepository : RepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }

        public async Task<PagingDataList<VehicleMake>> GetAllVehicleMake(PagingData pagingData = null)
        {

            var allVehicleMake = FindAll();


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
    }
}
