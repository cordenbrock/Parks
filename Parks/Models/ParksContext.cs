using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
  public class ParksContext : DbContext
  {
    public ParksContext(DbContextOptions<ParksContext> options)
        : base(options)
    {
    }

    public DbSet<NationalPark> NationalParks { get; set; }
    public DbSet<StatePark> StateParks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<NationalPark>()
      .HasData(
        new NationalPark { NationalParkId=1, Name = "Joshua Tree", State = "CA", Description = "Weird-looking trees" }  
      );
    }
  }
}