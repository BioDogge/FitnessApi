using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IExerciseRepository
	{
		IEnumerable<Exercise> GetAllExercises(int userId);
		Exercise GetExerciseById(int exerciseId, int userId);
		void CreateExercise(Exercise exercise, int userId);
		void DeleteExercise(Exercise exercise);

		bool SaveChanges();
	}
}