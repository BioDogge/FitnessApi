using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.EatingsDto;
using FitnessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApi.Controllers
{
	[Route("api/users/{userId}/[controller]")]
	[ApiController]
	public class EatingsController : Controller
	{
		private readonly IEatingRepository _repository;
		private readonly IMapper _mapper;

		public EatingsController(IEatingRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<EatingReadDto>> GetAllEatings(int userId)
		{
			var eatings = _repository.GetAllEatings(userId);

			return Ok(_mapper.Map<IEnumerable<EatingReadDto>>(eatings));
		}

		[HttpPost("addEating")]
		public ActionResult<EatingReadDto> CreateEating(EatingCreateDto eatingCreateDto, int userId)
		{
			var foodsAndPortion = _mapper.Map<IEnumerable<FoodEating>>(eatingCreateDto.FoodsAndPortion);
			var eatingModel = _mapper.Map<Eating>(eatingCreateDto);

			_repository.CreateEating(eatingModel, foodsAndPortion, userId);
			_repository.SaveChanges();

			var eatingReadDto = _mapper.Map<Eating>(eatingModel);

			return Ok(eatingReadDto);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteEating(int id, int userId)
		{
			var eating = _repository.GetEating(id, userId);

			if (eating == null)
				return BadRequest();

			_repository.DeleteEating(eating);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}