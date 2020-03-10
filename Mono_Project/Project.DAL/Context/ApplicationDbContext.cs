using Microsoft.EntityFrameworkCore;
using Project.Model.Model;


namespace Project.DAL.Context
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options)
				: base(options)
		{
		}

		public DbSet<VehicleMake> VehicleMake { get; set; }
		public DbSet<VehicleModel> VehicleModel { get; set; }
	}
}
