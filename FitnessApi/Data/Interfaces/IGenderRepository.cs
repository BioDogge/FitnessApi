using FitnessApi.Models;

namespace FitnessApi.Data.Interfaces
{
	public interface IGenderRepository
	{
		IEnumerable<Gender> GetAllGenders();
		Gender GetGender(char name);
	}
}