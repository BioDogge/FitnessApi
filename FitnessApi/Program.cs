using FitnessApi.Data;
using FitnessApi.Data.Interfaces;
using FitnessApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace FitnessApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<FitnessDbContext>();

			builder.Services.AddControllers()
				.AddNewtonsoftJson(s =>
				{
					s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				});

			builder.Services.AddScoped<IGenderRepository, GenderRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
			builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
			builder.Services.AddScoped<IEatingRepository, EatingRepository>();
			builder.Services.AddScoped<IFoodRepository, FoodRepository>();

			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			builder.Services.AddAuthorization();

			var app = builder.Build();

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());

			PrepDb.PrepDatabase(app);

			app.Run();
		}
	}
}