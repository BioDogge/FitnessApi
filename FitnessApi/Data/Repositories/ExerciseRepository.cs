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

		public void CreateExercise(Exercise exercise)
		{
			if (exercise != null)
				_context.Exercises.Add(exercise);
			else
				throw new ArgumentNullException(nameof(exercise));
		}

		public void DeleteExercise(Exercise exercise)
		{
			if (exercise != null)
				_context.Exercises.Remove(exercise);
			else
				throw new ArgumentNullException(nameof(exercise));
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