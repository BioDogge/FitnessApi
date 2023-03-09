using FitnessApi.Dtos.ActivitiesDto;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessApi.Tests
{
	public class ActivitiesControllerTests
	{
		private readonly IMapper _mapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new FitnessProfile());
		}).CreateMapper();

		private readonly Mock<IActivityRepository> _mock = new Mock<IActivityRepository>();

		[Fact]
		public void GetAllActivitiesFromRepository()
		{
			_mock.Setup(m => m.GetAllActivities())
				.Returns((new Activity[]
				{
					new Activity() { Id = 1, Name = "Test1", CaloriesPerMinute = 5m},
					new Activity() { Id = 2, Name = "Test2", CaloriesPerMinute = 10m}
				}).AsEnumerable());

			ActivitiesController controller = new ActivitiesController(_mock.Object, _mapper);

			IEnumerable<ActivityReadDto> result = (controller.GetAllActivities().Result as OkObjectResult)
				?.Value as IEnumerable<ActivityReadDto> ?? Enumerable.Empty<ActivityReadDto>();

			ActivityReadDto[] resultToArray = result.ToArray();

			Assert.True(resultToArray.Length == 2);
			Assert.Equal("Test1", resultToArray[0].Name);
			Assert.Equal("Test2", resultToArray[1].Name);
		}
	}
}