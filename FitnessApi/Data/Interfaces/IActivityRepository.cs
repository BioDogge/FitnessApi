using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IActivityRepository
	{
		IEnumerable<Activity> GetAllActivities();
		Activity GetActivityById(int id);
	}
}