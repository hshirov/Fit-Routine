using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FitRoutineContext : DbContext
    {
        public FitRoutineContext(DbContextOptions options) : base(options) { }
        public FitRoutineContext() { }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed for days of week
            modelBuilder.Entity<Day>().HasData(
                new Day { Id = 1, Name = "Monday", IsRestDay = false },
                new Day { Id = 2, Name = "Tuesday", IsRestDay = true },
                new Day { Id = 3, Name = "Wednesday", IsRestDay = false },
                new Day { Id = 4, Name = "Thursday", IsRestDay = true },
                new Day { Id = 5, Name = "Friday", IsRestDay = false },
                new Day { Id = 6, Name = "Saturday", IsRestDay = true },
                new Day { Id = 7, Name = "Sunday", IsRestDay = true }
            );
        }
    }
}
