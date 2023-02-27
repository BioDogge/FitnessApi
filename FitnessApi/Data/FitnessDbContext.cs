using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApi.Data
{
	public class FitnessDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=FitnessDatabase.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Food>()
				.HasMany(f => f.Eatings)
				.WithMany(e => e.Foods)
				.UsingEntity<FoodEating>(
				u => u
					.HasOne(fe => fe.Eating)
					.WithMany(e => e.FoodEatings)
					.HasForeignKey(fe => fe.EatingId),
				u => u
					.HasOne(fe => fe.Food)
					.WithMany(f => f.FoodEatings)
					.HasForeignKey(fe => fe.FoodId),
				u =>
				{
					u.HasKey(k => new { k.FoodId, k.EatingId });
					u.ToTable(nameof(FoodEating));
				});
		}

		public DbSet<Exercise> Exercises => Set<Exercise>();
		public DbSet<Activity> Activities => Set<Activity>();
		public DbSet<Gender> Genders => Set<Gender>();
		public DbSet<User> Users => Set<User>();
		public DbSet<Vitamin> Vitamins => Set<Vitamin>();
		public DbSet<Food> Foods => Set<Food>();
		public DbSet<Eating> Eatings => Set<Eating>();
		public DbSet<FoodEating> FoodEatings => Set<FoodEating>();
	}
}