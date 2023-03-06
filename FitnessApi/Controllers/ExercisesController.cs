using AutoMapper;
using FitnessApi.Data.Interfaces;
using FitnessApi.Dtos.ExercisesDto;
using FitnessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApi.Controllers
{
	[Route("api/users/{userId}/[controller]")]
	[ApiController]
	public class ExercisesController : Controller
	{
		private readonly IExerciseRepository _repository;
		private readonly IMapper _mapper;

		public ExercisesController(IExerciseRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ExerciseReadDto>> GetAllExercises(int userId)
		{
			var exercises = _repository.GetAllExercises(userId);

			return Ok(_mapper.Map<IEnumerable<ExerciseReadDto>>(exercises));
		}

		[HttpGet("{id}")]
		public ActionResult<ExerciseReadDto> GetExerciseById(int id, int userId)
		{
			var exercise = _repository.GetExerciseById(id, userId);

			if (exercise == null)
				return BadRequest();

			return Ok(_mapper.Map<ExerciseReadDto>(exercise));
		}

		[HttpPost("addExercise")]
		public ActionResult<ExerciseReadDto> CreateExercise(ExerciseCreateDto exerciseCreateDto, int userId)
		{
			var exerciseModel = _mapper.Map<Exercise>(exerciseCreateDto);
			_repository.CreateExercise(exerciseModel, userId);
			_repository.SaveChanges();

			var exerciseReadDto = _mapper.Map<ExerciseReadDto>(exerciseModel);
			return Ok(exerciseReadDto);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteExercise(int id, int userId)
		{
			var exercise = _repository.GetExerciseById(id, userId);

			if (exercise == null)
				return BadRequest();

			_repository.DeleteExercise(exercise);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}