namespace FitnessApi.Infrastructure
{
	public class CalculateCaloriesForExercise
	{
		//HACK: Perhaps this class need to be changed to Static.

		private readonly TimeSpan _startTime;
		private readonly TimeSpan _finishTime;
		private readonly decimal _exerciseTime;
		private readonly decimal _caloriesPerMinute;

		public CalculateCaloriesForExercise(TimeSpan startTime, TimeSpan finishTime, decimal caloriesPerMinute)
        {
            _startTime = startTime;
			_finishTime = finishTime;
			_caloriesPerMinute = caloriesPerMinute;
			_exerciseTime = GetExerciseTime();
        }

        private decimal GetExerciseTime() => (decimal)_finishTime.Subtract(_startTime).TotalMinutes;

		public decimal GetBurnedCalories() => _exerciseTime * _caloriesPerMinute;
	}
}