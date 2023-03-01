using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.FoodsDto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodsController : Controller
	{
		private readonly IFoodRepository _repository;
		private readonly IMapper _mapper;

		public FoodsController(IFoodRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<FoodWithoutVitaminsReadDto>> GetAllFoods()
		{
			var foods = _repository.GetAllFoods();

			return Ok(_mapper.Map<IEnumerable<FoodWithoutVitaminsReadDto>>(foods));
		}

		[HttpGet("{id}")]
		public ActionResult<FoodWithVitaminsReadDto> GetFoodWithVitaminsById(int id)
		{
			var food = _repository.GetFoodByIdWithVitamins(id);

			if (food == null)
				BadRequest();

			return Ok(_mapper.Map<FoodWithVitaminsReadDto>(food));
		}
	}
}