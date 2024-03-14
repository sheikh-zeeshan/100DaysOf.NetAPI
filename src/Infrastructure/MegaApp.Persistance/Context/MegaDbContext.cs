using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Context;

public class MegaDbContext : DbContext
{


    public MegaDbContext(DbContextOptions<MegaDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"hostels.sdb");

        optionsBuilder.AddInterceptors(new PerformanceInterceptor());

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

        // new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);


    }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
}


