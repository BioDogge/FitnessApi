using FitnessApi.Dtos.VitaminsDto;
using FitnessApi.Models;

namespace FitnessApi.Dtos.FoodsDto
{
	public class FoodWithVitaminsReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Proteins { get; set; }

		public decimal Fats { get; set; }

		public decimal Carbohydrates { get; set; }

		public decimal Calories { get; set; }

		public VitaminReadDto? Vitamin { get; set; }
	}
}