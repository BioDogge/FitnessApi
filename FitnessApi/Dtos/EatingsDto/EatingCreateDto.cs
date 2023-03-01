namespace FitnessApi.Dtos.EatingsDto
{
	public class EatingCreateDto
	{
		public int UserId { get; set; }

		public DateTime MealDate { get; set; }

		public TimeSpan MealTime { get; set; }

		public ICollection<FoodEatingCreateDto>? FoodsAndPortion { get; set; }
	}

	public class FoodEatingCreateDto
	{
		public int FoodId { get; set; }

		public decimal PortionSize { get; set; }
	}
}