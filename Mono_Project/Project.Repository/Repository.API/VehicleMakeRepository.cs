using Project.DAL.Context;
using Project.Model.Model;
using Project.Repository.Common.Interfaces.API;


namespace Project.Repository.API
{
    public class VehicleMakeRepository : RepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
