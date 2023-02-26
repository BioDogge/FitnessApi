using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Dtos.UsersDto
{
	public class UserShortInfoReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }

		public decimal Weight { get; set; }

		public decimal Height { get; set; }

		public char GenderName { get; set; }
	}
}