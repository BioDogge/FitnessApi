using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int Age { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Weight { get; set; }

		[Required]
		[Column(TypeName = "decimal(4,1)")]
		public decimal Height { get; set; }

		[Column(TypeName = "char(1)")]
		public char GenderName { get; set; }
		public Gender Gender { get; set; }

		public ICollection<Exercise>? Exercises { get; set; }
		public ICollection<Eating>? Eatings { get; set; }
	}
}