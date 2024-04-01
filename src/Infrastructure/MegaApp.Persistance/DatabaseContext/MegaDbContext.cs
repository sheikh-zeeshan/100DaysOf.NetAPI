using MegaApp.Domain.Common;
using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.DatabaseContext.Configurations;

public class MegaDbContext : DbContext
{
    public MegaDbContext()
    { }

    public MegaDbContext(DbContextOptions<MegaDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data source = ..\..\..\..\MegaAppDB.sdb;");
        //, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)- //use split behavioud by default then use AsSingleQuery

        optionsBuilder.AddInterceptors(new PerformanceInterceptor());

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // new AppUserConfiguration().Configure(modelBuilder.Entity<AppUser>());
        // new LeaveTypeConfiguration().Configure(modelBuilder.Entity<LeaveType>());
        // new TenantConfiguration().Configure(modelBuilder.Entity<Tenant>());
        // new TenantHostelConfiguration().Configure(modelBuilder.Entity<TenantHostel>());
        // new HostelRoomConfiguration().Configure(modelBuilder.Entity<HostelRoom>());
        // new TenantHostelEmployeeConfiguration().Configure(modelBuilder.Entity<TenantHostelEmployee>());
        // new TenantHostelSubscriptionConfiguration().Configure(modelBuilder.Entity<TenantHostelSubscription>());
        // new RoomOccupantConfiguration().Configure(modelBuilder.Entity<RoomOccupant>());

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<TenantHostelEmployee> Employees { get; set; }
    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<HostelRoom> HostelRooms { get; set; }
    public DbSet<RoomOccupant> RoomOccupants { get; set; }
    public DbSet<TenantHostel> TenantHostels { get; set; }
    //  public DbSet<TenantHostelSubscription> TenantHostelSubscriptions { get; set; }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<TenantHostelTag> TenantHostelTags { get; set; }

    private void SetAuditFields()
    {
        foreach (var entry in base.ChangeTracker.Entries<AuditableEntity /*<object>*/>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.ModifiedOn = DateTime.Now;
            else
                entry.Entity.CreatedOn = DateTime.Now;
        }
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        SetAuditFields();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        SetAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetAuditFields();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override int SaveChanges()
    {
        SetAuditFields();
        return base.SaveChanges();
    }
}