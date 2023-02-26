using FitnessApi.Models;

namespace FitnessApi.Dtos.UsersDto
{
	public class UserFullInfoReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }

		public decimal Weight { get; set; }

		public decimal Height { get; set; }

		public char GenderName { get; set; }

		//HACK: Change to DTO objects.

		public ICollection<Exercise>? Exercises { get; set; }
		public ICollection<Eating>? Eatings { get; set; }
	}
}