using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
		void CreateUser(User user);
		void UpdateUser(User user);
		void DeleteUser(User user);

		bool SaveChanges();
	}
}