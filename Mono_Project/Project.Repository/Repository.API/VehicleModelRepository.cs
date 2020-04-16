using Microsoft.EntityFrameworkCore;
using Project.Common;
using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository.API
{
    public class VehicleModelRepository : RepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }

       public async Task<PagingDataList<VehicleModel>> GetAllVehicleModel(PagingData pagingData = null) {

                var allVehicleModel = FindAll();


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
    }
}

