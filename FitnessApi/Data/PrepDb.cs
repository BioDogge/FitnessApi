using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data
{
	/// <summary>
	/// Class needed to seed data in the Genders table.
	/// </summary>
	public static class PrepDb
	{
		public static void PrepDatabase(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				SeedData(serviceScope.ServiceProvider.GetService<FitnessDbContext>());
			}
		}

		private static void SeedData(FitnessDbContext context)
		{
			try
			{
				context.Database.Migrate();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"--> Could not run migrations: {ex.Message}");
			}

			if (!context.Genders.Any())
			{
				Console.WriteLine("--> Seeding data in Genders...");

				context.Genders.AddRange(
					new Gender() { Name = 'M' },
					new Gender() { Name = 'W' }
					);

				context.SaveChanges();
			}
			else
				Console.WriteLine("--> Database already have data");
		}
	}
}