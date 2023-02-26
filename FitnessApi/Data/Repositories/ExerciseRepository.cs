using FitnessApi.Data.Interfaces;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly FitnessDbContext _context;

		public ExerciseRepository(FitnessDbContext context)
		{
			_context = context;
		}

		public void CreateExercise(Exercise exercise, int userId)
		{
			if (exercise == null)
				throw new ArgumentNullException(nameof(exercise));

			exercise.UserId = userId;
			_context.Exercises.Add(exercise);
		}

		public void DeleteExercise(Exercise exercise)
		{
			if (exercise == null)
				throw new ArgumentNullException(nameof(exercise));

			_context.Exercises.Remove(exercise);
		}

		public IEnumerable<Exercise> GetAllExercises(int userId)
		{
			return _context.Exercises.Include(e => e.Activity)
				.Where(e => e.UserId == userId).ToList();
		}

		public Exercise GetExercise(int exerciseId, int userId)
		{
			return _context.Exercises.Include(e => e.Activity)
				.Where(e => e.UserId == userId).FirstOrDefault(e => e.Id == exerciseId);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}