using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealEstate.Entities;


namespace RealEstate.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder
				.EnableDetailedErrors(true)
				.EnableSensitiveDataLogging(true);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Using fluent API to configure entities: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
			builder.Entity<Property>()
				.HasMany(p => p.Assets)
				.WithOne(a => a.Property);

			builder.Entity<Property>()
				.ToTable("Properties")
				.HasKey(x => x.Id);

			builder.Entity<PropertyAsset>()
				.ToTable("PropertyAssets")
				.HasKey(x => x.Id);

			// Seed some data: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
			var (properties, assets) = RealEstateHelpers.CreateProperties();
			builder.Entity<Property>().HasData(properties);
			builder.Entity<PropertyAsset>().HasData(assets);
		}

		public DbSet<Property> Properties { get; set; }
	}
}
