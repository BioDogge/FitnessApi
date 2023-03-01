using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IFoodRepository
	{
		IEnumerable<Food> GetAllFoods();
		Food GetFoodByIdWithVitamins(int id);
	}
}