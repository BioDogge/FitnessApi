using FitnessApi.Data.Interfaces;
using FitnessApi.Models;

namespace FitnessApi.Data.Repositories
{
	public class GenderRepository : IGenderRepository
	{
		private readonly FitnessDbContext _context;

		public GenderRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gender> GetAllGenders()
		{
			return _context.Genders.ToList();
		}

		public Gender GetGender(char name)
		{
			return _context.Genders.FirstOrDefault(g => g.Name == name);
		}
	}
}