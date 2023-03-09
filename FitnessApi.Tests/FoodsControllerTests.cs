using FitnessApi.Dtos.ActivitiesDto;
using FitnessApi.Dtos.FoodsDto;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessApi.Tests
{
	public class FoodsControllerTests
	{
		private readonly IMapper _mapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new FitnessProfile());
		}).CreateMapper();

		private readonly Mock<IFoodRepository> _mock = new Mock<IFoodRepository>();

		[Fact]
		public void GetAllFoodsFromRepository()
		{
			_mock.Setup(m => m.GetAllFoods())
				.Returns((new Food[]
				{
					new Food() { Id = 1, Name = "FirstFood", Calories = 10, Carbohydrates = 15, Fats = 5, Proteins = 3},
					new Food() { Id = 2, Name = "SecondFood", Calories = 20, Carbohydrates = 18, Fats = 7, Proteins = 5},
					new Food() { Id = 3, Name = "EmptyFood", Calories = 0, Carbohydrates = 0, Fats = 0, Proteins = 0}
				}).AsEnumerable());

			FoodsController controller = new FoodsController(_mock.Object, _mapper);

			IEnumerable<FoodWithoutVitaminsReadDto> result = (controller.GetAllFoods().Result as OkObjectResult)
				?.Value as IEnumerable<FoodWithoutVitaminsReadDto> ?? Enumerable.Empty<FoodWithoutVitaminsReadDto>();

			FoodWithoutVitaminsReadDto[] resultToArray = result.ToArray();

			Assert.True(resultToArray.Length == 3);
			Assert.Equal("FirstFood", resultToArray[0].Name);
			Assert.Equal("SecondFood", resultToArray[1].Name);
			Assert.True(resultToArray[2].Fats == 0 && resultToArray[2].Calories == 0);
		}
	}
}
