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

			//UNDONE: This DbContext for the development environment.
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
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
			app.UseSwaggerUI(opts =>
			{
				opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				opts.RoutePrefix = string.Empty;
			});

			PrepDb.PrepDatabase(app);

			app.Run();
		}
	}
}