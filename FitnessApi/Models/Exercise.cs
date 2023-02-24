using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Models
{
	/// <summary>
	/// User's exercises. This class is required for calculate burned calories which are based on the selected activity and exercise time.
	/// </summary>
	public class Exercise
	{
		[Key]
		public int Id { get; set; }

		public int ActivityId { get; set; }
		public Activity? Activity { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; }

		[Required]
		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime StartTime { get; set; }

		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime FinishTime { get; set; }

		/// <summary>
		/// Number of calories burned per exercise.
		/// </summary>
		[Column(TypeName = "decimal(5,1)")]
		public decimal BurnedCalories { get; set; }
	}
}