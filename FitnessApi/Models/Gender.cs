using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApi.Models
{
	/// <summary>
	/// User's gender.
	/// </summary>
	public class Gender
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column(TypeName = "char(1)")]
		public char Name { get; set; }

		public ICollection<User>? Users { get; set; }
	}
}