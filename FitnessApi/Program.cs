using FitnessApi.Data;
using FitnessApi.Data.Interfaces;
using FitnessApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<FitnessDbContext>();

			builder.Services.AddScoped<IGenderRepository, GenderRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
			builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
			builder.Services.AddScoped<IEatingRepository, EatingRepository>();
			builder.Services.AddScoped<IFoodRepository, FoodRepository>();

			builder.Services.AddAuthorization();

			var app = builder.Build();

			app.UseAuthorization();

			app.Run();
		}
	}
}