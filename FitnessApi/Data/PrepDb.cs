using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data
{
	/// <summary>
	/// Class needed to seed data in the tables.
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
			//HACK: Recreation the database

			//context.Database.EnsureDeleted();

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

			Console.WriteLine("Genders table have data");

			if(!context.Users.Any())
			{
				Console.WriteLine("--> Seeding data in Users...");

				context.Users.Add(new User { Name = "Ivan", Age = 20, Weight = 80.6m, Height = 180, GenderName = 'M'});

				context.SaveChanges();
			}

			Console.WriteLine("Users table have data");

			if (!context.Activities.Any())
			{
				Console.WriteLine("--> Seeding data in Activities...");

				context.Activities.AddRange(
					new Activity() { Name = "Running", CaloriesPerMinute = 13.3m },
					new Activity() { Name = "Walking", CaloriesPerMinute = 3.5m },
					new Activity() { Name = "Strength training", CaloriesPerMinute = 15.5m },
					new Activity() { Name = "Stretching", CaloriesPerMinute = 1.8m },
					new Activity() { Name = "Cycling", CaloriesPerMinute = 11m });

				context.SaveChanges();
			}

			Console.WriteLine("Activities table have data");

			if (!context.Foods.Any())
			{
				Console.WriteLine("--> Seeding data in Foods and Vitamins...");

				context.Foods.AddRange(
						new Food() { Name = "Banana", Proteins = 0.74m, Fats = 0.29m, Carbohydrates = 23m, Calories = 88m },
						new Food() { Name = "Broccoli", Proteins = 2.57m, Fats = 0.34m, Carbohydrates = 6.27m, Calories = 32m },
						new Food() { Name = "Egg", Proteins = 13m, Fats = 11m, Carbohydrates = 1.1m, Calories = 155m },
						new Food() { Name = "Milk (1% milkfat)", Proteins = 3.4m, Fats = 1m, Carbohydrates = 5m, Calories = 42m },
						new Food() { Name = "Rice", Proteins = 2.69m, Fats = 0.3m, Carbohydrates = 28m, Calories = 130m });

				context.Vitamins.AddRange(
					new Vitamin() { FoodId = 1, Calcium = 5m, Iron = 0.3m, Magnesium = 27m, VitaminB12 = 0m, VitaminB6 = 0.4m, VitaminC = 8.7m, VitaminD = 0m},
					new Vitamin() { FoodId = 2, Calcium = 47m, Iron = 0.7m, Magnesium = 21m, VitaminB12 = 0m, VitaminB6 = 0.2m, VitaminC = 89.2m, VitaminD = 0m },
					new Vitamin() { FoodId = 3, Calcium = 50m, Iron = 1.2m, Magnesium = 10m, VitaminB12 = 1.1m, VitaminB6 = 0.1m, VitaminC = 0m, VitaminD = 87m },
					new Vitamin() { FoodId = 4, Calcium = 126m, Iron = 0m, Magnesium = 12m, VitaminB12 = 0.61m, VitaminB6 = 0.06m, VitaminC = 0m, VitaminD = 42.4m },
					new Vitamin() { FoodId = 5, Calcium = 10m, Iron = 0.2m, Magnesium = 12m, VitaminB12 = 0m, VitaminB6 = 0.1m, VitaminC = 0m, VitaminD = 0m });

				context.SaveChanges();
			}

			Console.WriteLine("Foods and Vitamins tables have data");

			if (!context.Eatings.Any())
			{
				Console.WriteLine("--> Seeding data in Eatings...");

				context.Eatings.Add(
					new Eating() { UserId = 1, MealDate = DateTime.Now.Date, MealTime = DateTime.Now.TimeOfDay});

				context.FoodEatings.AddRange(
					new FoodEating() { EatingId = 1, FoodId = 1, PortionSize = 100 },
					new FoodEating() { EatingId = 1, FoodId = 2, PortionSize = 50});

				context.SaveChanges();
			}

            Console.WriteLine("Eating table have data");
        }
	}
}