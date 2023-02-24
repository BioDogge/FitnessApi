using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Models
{
	/// <summary>
	/// This class describes food vitamins (in 100 grams).
	/// </summary>
	public class Vitamin
	{
		[Key]
		public int FoodId { get; set; }
		public Food? Food { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal VitaminC { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal VitaminB6 { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal VitaminB12 { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal VitaminD { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Iron { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Magnesium { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Calcium { get; set; }
	}
}