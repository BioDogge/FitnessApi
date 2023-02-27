using FitnessApi.Data.Interfaces;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data.Repositories
{
	public class EatingRepository : IEatingRepository
	{
		private readonly FitnessDbContext _context;

		public EatingRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public void CreateEating(Eating eating, Dictionary<int, decimal> foodAndPortionSize, int userId)
		{
			if (eating != null && foodAndPortionSize.Count() > 0)
			{
				eating.UserId = userId;

				foreach (var item in foodAndPortionSize)
				{
					if (IsExistingFood(item.Key))
					{
						eating.FoodEatings.Add(new FoodEating { FoodId = item.Key, PortionSize = item.Value });
						_context.Eatings.Add(eating);
					}
				}
			}
			else
				throw new ArgumentNullException(nameof(eating));
		}

		public void DeleteEating(Eating eating)
		{
			if (eating != null)
				_context.Eatings.Remove(eating);
		}

		public IEnumerable<Food> ExistingFood(IEnumerable<int> foodId)
		{
			//HACK: Maybe this method needs to be removed.
			throw new NotImplementedException();
		}

		public IEnumerable<Eating> GetAllEatings(int userId)
		{
			return _context.Eatings.Include(e => e.Foods).ThenInclude(f => f.Vitamin)
				.Where(e => e.UserId == userId).ToList();
		}

		public Eating GetEating(int eatingId, int userId)
		{
			return _context.Eatings.Include(e => e.Foods).ThenInclude(f => f.Vitamin)
				.Where(e => e.UserId == userId).FirstOrDefault(e => e.Id == eatingId);
		}

		public bool IsExistingFood(int foodId)
		{
			return _context.Foods.Any(f => f.Id == foodId);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}