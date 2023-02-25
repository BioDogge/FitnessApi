using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IFoodRepository
	{
		IEnumerable<Food> GetAllFoodsWithoutVitamins();
		IEnumerable<Food> GetAllFoodsWithVitamins();
		Food GetFoodWithoutVitamins(int id);
		Food GetFoodWithVitamins(int id);
	}
}