using FitnessApi.Data.Interfaces;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data.Repositories
{
	public class FoodRepository : IFoodRepository
	{
		private readonly FitnessDbContext _context;

		public FoodRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Food> GetAllFoods()
		{
			return _context.Foods.ToList();
		}

		public Food GetFoodByIdWithVitamins(int id)
		{
			return _context.Foods.Include(f => f.Vitamin).FirstOrDefault(f => f.Id == id);
		}
	}
}