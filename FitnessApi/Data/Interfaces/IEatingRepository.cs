﻿using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IEatingRepository
	{
		IEnumerable<Eating> GetAllEatings(int userId);
		Eating GetEating(int eatingId, int userId);
		void CreateEating(Eating eating, Dictionary<int, decimal> foodAndPortionSize);
		void DeleteEating(Eating eating);

		bool IsExistingFood(int foodId);
		IEnumerable<Food> ExistingFood(IEnumerable<int> foodId);

		bool SaveChanges();
	}
}