using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IExerciseRepository
	{
		IEnumerable<Exercise> GetAllExercises(int userId);
		Exercise GetExercise(int exerciseId, int userId);
		void CreateExercise(Exercise exercise);
		void DeleteExercise(Exercise exercise);

		bool SaveChanges();
	}
}