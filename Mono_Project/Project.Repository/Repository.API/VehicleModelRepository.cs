using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;
namespace Project.Repository.API
{
    public class VehicleModelRepository : RepositoryBase<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
