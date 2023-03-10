namespace FitnessApi.Dtos.EatingsDto
{
	public class EatingReadDto
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public DateTime MealDate { get; set; }

		public TimeSpan MealTime { get; set; }

		public ICollection<FoodEatingReadDto>? FoodsAndPortion { get; set; }
	}

	public class FoodEatingReadDto
	{
		public int EatingId { get; set; }

		public int FoodId { get; set; }

		public decimal PortionSize { get; set; }
	}
}