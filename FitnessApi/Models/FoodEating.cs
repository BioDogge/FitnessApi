using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	/// <summary>
	/// This class is required for linking the meal and the selected food.
	/// </summary>
	public class FoodEating
	{
		public int EatingId { get; set; }
		public Eating? Eating { get; set; }

		public int FoodId { get; set; }
		public Food? Food { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal PortionSize { get; set; }
	}
}