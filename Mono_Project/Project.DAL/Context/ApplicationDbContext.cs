using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Project.Model.Model;


namespace Project.DAL.Context
{
	public class ApplicationContext : DbContext
	{
		public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
		
		public ApplicationContext()

		{

		}
		public ApplicationContext(DbContextOptions options)
				: base(options)
		{
		}

		public DbSet<VehicleMake> VehicleMake { get; set; }
		public DbSet<VehicleModel> VehicleModel { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
			=> optionsBuilder.UseLazyLoadingProxies()
			.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
			.EnableSensitiveDataLogging();
	}
}
