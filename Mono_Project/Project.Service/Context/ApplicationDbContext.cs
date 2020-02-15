using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.Service.Model;


namespace Project.Service.Context
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
