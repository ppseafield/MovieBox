namespace MovieBox.DB;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

public class MovieReviewContext : DbContext
{
  public DbSet<MovieReview> MovieReview { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var dbPassword = Environment.GetEnvironmentVariable("MSSQL_PASSWORD") ?? "";
    Console.WriteLine($"MSSQL_PASSWORD: {dbPassword}");
    optionsBuilder
      .UseSqlServer($"Server=localhost;Database=MovieBox;User Id=moviebox_user;Password={dbPassword};TrustServerCertificate=True;Encrypt=False;")
      .LogTo(Console.WriteLine, LogLevel.Information);
  }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("dbo");
      base.OnModelCreating(modelBuilder);
    }
}

public class MovieReview
{
  public int id { get; set; }
  public DateTime created_on { get; set; } = DateTime.Now;
  public string movie_title { get; set; } = "";
  public string movie_year { get; set; } = "";
  public int rating { get; set; } = 0;
  public string review_title { get; set; } = "";
  public string review_body { get; set; } = "";
}