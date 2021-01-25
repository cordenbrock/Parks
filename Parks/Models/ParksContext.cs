using Microsoft.EntityFrameworkCore;
using System;

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
        new NationalPark { NationalParkId=1, Name = "Joshua Tree NP", State = "CA", Description = "Weird-looking trees" },
        new NationalPark { NationalParkId=2, Name = "Arches NP", State = "UT", Description = "Weird-looking rocks" },
        new NationalPark { NationalParkId=3, Name = "Everglades NP", State = "FL", Description = "Weird-looking Gators" }  
      );
      builder.Entity<StatePark>()
      .HasData(
        new StatePark { StateParkId=1, Name = "Turkey Run SP", Location = "IN", Description = "Weird-looking trees" },
        new StatePark { StateParkId=2, Name = "Snow Canyon SP", Location = "UT", Description = "Weird-looking lizards" },
        new StatePark { StateParkId=3, Name = "Valley of Fire SP", Location = "NV", Description = "Weird-looking plants" }  
      );
    }
  }
}