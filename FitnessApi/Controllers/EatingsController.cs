using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.EatingsDto;
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
	}
}