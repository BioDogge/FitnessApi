using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	/// <summary>
	/// This class describes available activity for User.
	/// </summary>
	public class Activity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Column(TypeName = "decimal(5,1)")]
		public decimal CaloriesPerMinute { get; set; }

		public ICollection<Exercise>? Exercises { get; set; }
	}
}