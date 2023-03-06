using FitnessApi.Dtos.EatingsDto;
using FitnessApi.Dtos.ExercisesDto;

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

		public ICollection<ExerciseReadDto>? Exercises { get; set; }
		public ICollection<EatingReadDto>? Eatings { get; set; }
	}
}