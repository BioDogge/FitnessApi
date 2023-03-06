using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.ActivitiesDto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivitiesController : Controller
	{
		private readonly IActivityRepository _repository;
		private readonly IMapper _mapper;

		public ActivitiesController(IActivityRepository repository, IMapper mapper)
        {
            _repository = repository;
			_mapper = mapper;
        }

		[HttpGet]
		public ActionResult<IEnumerable<ActivityReadDto>> GetAllActivities() 
		{
			var activities = _repository.GetAllActivities();

			return Ok(_mapper.Map<IEnumerable<ActivityReadDto>>(activities));
		}

		[HttpGet("{id}")]
		public ActionResult<ActivityReadDto> GetActivityById (int id)
		{
			var activity = _repository.GetActivityById(id);

			if (activity == null)
				return BadRequest();

			return Ok(_mapper.Map<ActivityReadDto>(activity));
		}
    }
}
