namespace FitnessApi.Dtos.ExercisesDto
{
	public class ExerciseReadDto
	{
		public int Id { get; set; }

		public int ActivityId { get; set; }

		public int UserId { get; set; }

		public DateTime Date { get; set; }

		public TimeSpan StartTime { get; set; }

		public TimeSpan FinishTime { get; set; }

		public decimal BurnedCalories { get; set; }
	}
}