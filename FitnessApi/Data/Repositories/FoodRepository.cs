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

        public IEnumerable<Food> GetAllFoodsWithoutVitamins()
		{
			return _context.Foods.ToList();
		}

		public IEnumerable<Food> GetAllFoodsWithVitamins()
		{
			return _context.Foods.Include(f => f.Vitamin).ToList();
		}

		public Food GetFoodWithoutVitamins(int id)
		{
			return _context.Foods.FirstOrDefault(f => f.Id == id);
		}

		public Food GetFoodWithVitamins(int id)
		{
			return _context.Foods.Include(f => f.Vitamin).FirstOrDefault(f => f.Id == id);
		}
	}
}