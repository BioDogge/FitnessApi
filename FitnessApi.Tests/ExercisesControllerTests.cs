using FitnessApi.Dtos.ActivitiesDto;
using FitnessApi.Dtos.ExercisesDto;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessApi.Tests
{
	public class ExercisesControllerTests
	{
		private readonly IMapper _mapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new FitnessProfile());
		}).CreateMapper();

		private readonly Mock<IExerciseRepository> _mock = new Mock<IExerciseRepository>();

		[Fact]
		public void GetAllExercisesFromRepository()
		{
			int userId = 1;
			int firstActivityId = 1;
			int secondActivityId = 2;

			_mock.Setup(m => m.GetAllExercises(userId))
				.Returns((new Exercise[]
				{
					new Exercise() { Id = 1, UserId = 1, StartTime = TimeSpan.Parse("20:00"), FinishTime = TimeSpan.Parse("21:00"), ActivityId = firstActivityId},
					new Exercise() { Id = 2, UserId = 1, StartTime = TimeSpan.Parse("21:00"), FinishTime = TimeSpan.Parse("22:30"), ActivityId = secondActivityId}
				}).AsEnumerable());

			ExercisesController controller = new ExercisesController(_mock.Object, _mapper);

			IEnumerable<ExerciseReadDto> result = (controller.GetAllExercises(userId).Result as OkObjectResult)
				?.Value as IEnumerable<ExerciseReadDto> ?? Enumerable.Empty<ExerciseReadDto>();

			ExerciseReadDto[] resultToArray = result.ToArray();

			Assert.True(resultToArray.Length == 2);
		}

		[Fact]
		public void CalculateBurnedCalories()
		{
			TimeSpan startTime = TimeSpan.Parse("22:00");
			TimeSpan finishTime = TimeSpan.Parse("23:00");
			decimal caloriesPerMinute = 5m;

			decimal expected = 300m;

			decimal actual = new CalculateCaloriesForExercise(startTime, finishTime, caloriesPerMinute).GetBurnedCalories();

			Assert.Equal(expected, actual);
		}
	}
}