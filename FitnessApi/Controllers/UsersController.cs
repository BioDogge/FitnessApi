using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.UsersDto;
using FitnessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : Controller
	{
		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<UserShortInfoReadDto>> GetAllUsers()
		{
			var users = _repository.GetAllUsers();

			return Ok(_mapper.Map<IEnumerable<UserShortInfoReadDto>>(users));
		}

		[HttpGet("{id}")]
		public ActionResult<UserFullInfoReadDto> GetFullUsersInfoById(int id)
		{
			var user = _repository.GetUserById(id);

			if (user == null)
				return BadRequest();

			return Ok(_mapper.Map<UserFullInfoReadDto>(user));
		}

		[Route("createUser")]
		[HttpPost]
		public ActionResult<UserShortInfoReadDto> CreateUser(UserCreateDto userCreateDto)
		{
			var userModel = _mapper.Map<User>(userCreateDto);
			_repository.CreateUser(userModel);
			_repository.SaveChanges();

			var userReadDto = _mapper.Map<UserShortInfoReadDto>(userModel);
			return Ok(userReadDto);
		}

		[HttpPut("{id}")]
		public ActionResult UpdateUser (UserUpdateDto userUpdateDto, int id)
		{
			var userModel = _repository.GetUserById(id);
			if (userModel == null)
				return BadRequest();

			_mapper.Map(userUpdateDto, userModel);

			_repository.UpdateUser(userModel);
			_repository.SaveChanges();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteUser(int id)
		{
			var userModel = _repository.GetUserById(id);
			if (userModel == null)
				return BadRequest();

			_repository.DeleteUser(userModel);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}