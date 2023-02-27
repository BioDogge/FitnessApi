using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Dtos.ExercisesDto
{
	public class ExerciseCreateDto
	{
		[Required]
		public int ActivityId { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public TimeSpan StartTime { get; set; }

		[Required]
		public TimeSpan FinishTime { get; set; }
	}
}