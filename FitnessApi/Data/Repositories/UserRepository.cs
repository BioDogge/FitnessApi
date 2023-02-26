using FitnessApi.Data.Interfaces;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly FitnessDbContext _context;

		public UserRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
		{
			if (user != null)
				_context.Users.Add(user);
			else
				throw new ArgumentNullException(nameof(user));
		}

		public void DeleteUser(User user)
		{
			if (user != null)
				_context.Users.Remove(user);
			else
				throw new ArgumentNullException(nameof(user));
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.Include(u => u.Gender).ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.Include(u => u.Gender).FirstOrDefault(u => u.Id == id);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}

		
		public void UpdateUser(User user)
		{
			//This method is empty because updating the users profile implemented throught AutoMapper. Magic!
		}
	}
}