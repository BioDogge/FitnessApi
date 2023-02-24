using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	/// <summary>
	/// This class describes date and time of user's meal.
	/// </summary>
	public class Eating
	{
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; }

		[Required]
		[Column(TypeName = "date")]
		public DateTime MealDate { get; set; }

		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime MealTime { get; set; }

		public ICollection<FoodEating>? FoodEatings { get; set; }
		public ICollection<Food>? Foods { get; set; }
	}
}