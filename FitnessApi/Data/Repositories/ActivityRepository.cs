using FitnessApi.Data.Interfaces;
using FitnessApi.Models;

namespace FitnessApi.Data.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly FitnessDbContext _context;

		public ActivityRepository(FitnessDbContext context)
        {
			_context = context;   
        }

        public Activity GetActivity(int id)
		{
			return _context.Activities.FirstOrDefault(a => a.Id == id);
		}

		public IEnumerable<Activity> GetAllActivities()
		{
			return _context.Activities.ToList();
		}
	}
}