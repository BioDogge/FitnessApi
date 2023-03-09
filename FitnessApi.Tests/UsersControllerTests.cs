using FitnessApi.Dtos.UsersDto;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessApi.Tests
{
	public class UsersControllerTests
	{
		private readonly IMapper _mapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new FitnessProfile());
		}).CreateMapper();

		private readonly Mock<IUserRepository> _mock = new Mock<IUserRepository>();

		//TODO: Need to add GetUserByHisIdFromRepo test

		[Fact]
		public void GetAllUsersFromRepository()
		{
			_mock.Setup(m => m.GetAllUsers()).Returns((new User[]
			{
				new User() { Id = 1, Name = "Test1", Age = 1, Weight = 10, Height = 10},
				new User() { Id = 2, Name = "Test2", Age = 2, Weight = 20, Height = 20}
			}).AsEnumerable());

			UsersController controller = new UsersController(_mock.Object, _mapper);

			IEnumerable<UserShortInfoReadDto> result = (controller.GetAllUsers().Result as OkObjectResult)
				?.Value as IEnumerable<UserShortInfoReadDto>?? Enumerable.Empty<UserShortInfoReadDto>();

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

			UsersController controller = new UsersController(_mock.Object, _mapper);

			UserShortInfoReadDto result = (controller.CreateUser(userDto).Result as OkObjectResult)
				?.Value as UserShortInfoReadDto ?? new();
			
			Assert.Equal(userDto.Name, result.Name);
			Assert.Equal(userDto.Age, result.Age);
			Assert.Equal(userDto.GenderName, result.GenderName);
		}
	}
}