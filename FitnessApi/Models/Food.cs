using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	/// <summary>
	/// This class describes nutritional value of food (in 100 grams).
	/// </summary>
	public class Food
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Proteins { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Fats { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Carbohydrates { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Calories { get; set; }

		public Vitamin? Vitamin { get; set; }

		public ICollection<FoodEating>? FoodEatings { get; set; }
		public ICollection<Eating>? Eatings { get; set; }
	}
}