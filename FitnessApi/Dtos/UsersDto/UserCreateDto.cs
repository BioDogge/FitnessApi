using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Dtos.UsersDto
{
	public class UserCreateDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public decimal Weight { get; set; }

		[Required]
		public decimal Height { get; set; }

		[Required]
		public char GenderName { get; set; }
	}
}