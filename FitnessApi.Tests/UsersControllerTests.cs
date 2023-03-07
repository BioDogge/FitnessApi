using FitnessApi.Dtos.UsersDto;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessApi.Tests
{
	public class UsersControllerTests
	{
		private readonly IMapper mapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new FitnessProfile());
		}).CreateMapper();

		[Fact]
		public void GetAllUsersFromRepository()
		{
			Mock<IUserRepository> mock = new Mock<IUserRepository>();
			mock.Setup(m => m.GetAllUsers()).Returns((new User[]
			{
				new User() { Id = 1, Name = "Test1", Age = 1, Weight = 10, Height = 10},
				new User() { Id = 2, Name = "Test2", Age = 2, Weight = 20, Height = 20}
			}).AsEnumerable());

			UsersController controller = new UsersController(mock.Object, mapper);

			IEnumerable<UserShortInfoReadDto> result = (controller.GetAllUsers().Result as OkObjectResult)?.Value as IEnumerable<UserShortInfoReadDto>
														?? Enumerable.Empty<UserShortInfoReadDto>();
			UserShortInfoReadDto[] resultToArray = result.ToArray();

			Assert.True(resultToArray.Length == 2);
			Assert.Equal("Test1", resultToArray[0].Name);
			Assert.Equal("Test2", resultToArray[1].Name);
		}

		[Fact]
		public void InsertUserToRepository()
		{
			UserCreateDto userDto = new UserCreateDto()
			{
				Name = "Test",
				Age = 1,
				Weight = 10,
				Height = 10,
				GenderName = 'M'
			};
			Mock<IUserRepository> mock = new Mock<IUserRepository>();

			UsersController controller = new UsersController(mock.Object, mapper);

			UserShortInfoReadDto result = (controller.CreateUser(userDto).Result as OkObjectResult)?.Value as UserShortInfoReadDto 
											?? new();
			
			Assert.Equal(userDto.Name, result.Name);
			Assert.Equal(userDto.Age, result.Age);
			Assert.Equal(userDto.GenderName, result.GenderName);
		}
	}
}