using FitnessApi.Dtos.FoodsDto;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessApi.Dtos.EatingsDto
{
	public class EatingReadDto
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public DateTime MealDate { get; set; }

		public TimeSpan MealTime { get; set; }

		public decimal PortionSize { get; set; }

		public ICollection<FoodWithVitaminsReadDto>? Foods { get; set; }
	}
}