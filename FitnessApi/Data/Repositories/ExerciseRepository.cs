using FitnessApi.Data.Interfaces;
using FitnessApi.Infrastructure;
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

		private decimal GetCaloriesPerMinuteFromActivity(int activityId)
		{
			return _context.Activities.FirstOrDefault(a => a.Id == activityId).CaloriesPerMinute;
		}

		public void CreateExercise(Exercise exercise, int userId)
		{
			if (exercise == null)
				throw new ArgumentNullException(nameof(exercise));

			var caloriesPerMinute = GetCaloriesPerMinuteFromActivity(exercise.ActivityId);
			exercise.BurnedCalories = new CalculateCaloriesForExercise(exercise.StartTime, exercise.FinishTime, caloriesPerMinute).GetBurnedCalories();
			
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
				.Where(e => e.UserId == userId)
				.ToList();
		}

		public Exercise GetExerciseById(int exerciseId, int userId)
		{
			return _context.Exercises.Include(e => e.Activity)
				.Where(e => e.UserId == userId)
				.FirstOrDefault(e => e.Id == exerciseId);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}