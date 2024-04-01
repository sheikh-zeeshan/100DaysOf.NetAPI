using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaApp.Persistance.DatabaseContext.Configurations;

/*
entry.ToTable("Addresses").HasKey(x => x.Id);
entry.Property(c => c.Id).HasColumnName("AddressId").ValueGeneratedOnAdd();
          */

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> modelBuilder)
    {
        // modelBuilder.Entity<Site>().ToTable("Site");

        // modelBuilder.Entity<User>(entry =>
        // {
        //     entry.ToTable("Site", tb => tb.HasTrigger("trg_SiteUpdate"));
        // });

        modelBuilder.ToTable("AppUsers").HasKey(x => x.Id);
        modelBuilder.Property(x => x.Id).HasColumnName("AppUserId").ValueGeneratedOnAdd();
        //modelBuilder.ToTable("Users", tb => tb.HasTrigger("trg_UserAdd"));

        modelBuilder.Property(b => b.Id).HasColumnName("AppUserId").IsRequired();
        modelBuilder.Property(b => b.FirstName).HasMaxLength(250).IsRequired();
        modelBuilder.Property(b => b.LastName).HasMaxLength(250).IsRequired();
        modelBuilder.Property(b => b.Email).IsRequired();
        modelBuilder.Property(b => b.Password).IsRequired();
        modelBuilder.Property(b => b.PhoneNo).IsRequired();
        modelBuilder.Property(b => b.UserName).HasMaxLength(50).IsRequired();

        modelBuilder.Property(p => p.Version).IsConcurrencyToken();

        modelBuilder.Property(b => b.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

        //.HasDefaultValue(3);
        // .HasDefaultValueSql("getdate()");
        //.HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        // .HasComputedColumnSql("LEN([LastName]) + LEN([FirstName])", stored: true);
    }
}

//Tenant
public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenant").HasKey(c => c.Id);
        builder.Property(x => x.Id).HasColumnName("TenantId").ValueGeneratedOnAdd();

        builder
        .HasMany(c => c.TenantHostels) // modelBuilder.Entity<College>()
        .WithOne(c => c.Tenant); // can be ued in other way start from child entity , hasone and with many

        builder
        .HasOne<Address>(c => c.Address)
        .WithOne(c => c.Tenant)
        .HasForeignKey<Address>(c => c.ParentId);
    }
}

//TenantHostel
public class TenantHostelConfiguration : IEntityTypeConfiguration<TenantHostel>
{
    public void Configure(EntityTypeBuilder<TenantHostel> builder)
    {
        builder.ToTable("TenantHostels").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("TenantHostelId").ValueGeneratedOnAdd();

        builder
        .HasMany(c => c.HostelRooms)
        .WithOne(c => c.TenantHostel)
        .HasForeignKey(x => x.TenantHostelId);

        builder
.HasMany(c => c.TenantHostEmployees)
.WithOne(c => c.TenantHostel)
.HasForeignKey(c => c.TenantHostelId);
    }
}

//HostelRoom
public class HostelRoomConfiguration : IEntityTypeConfiguration<HostelRoom>
{
    public void Configure(EntityTypeBuilder<HostelRoom> builder)
    {
        builder.ToTable("HostelRooms").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("HostelRoomId").ValueGeneratedOnAdd();

        builder
        .HasMany(c => c.RoomOccupants)
        .WithOne(c => c.HostelRoom)
        .HasForeignKey(c => c.HostelRoomId);
    }
}

//Tenant Hostel Employee
public class TenantHostelEmployeeConfiguration : IEntityTypeConfiguration<TenantHostelEmployee>
{
    public void Configure(EntityTypeBuilder<TenantHostelEmployee> builder)
    {
        builder.ToTable("TenantHostelEmployees").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("TenantHostelEmployeeId").ValueGeneratedOnAdd();

        builder.HasOne<LeaveAllocation>(c => c.LeaveAllocation)
        .WithOne(c => c.TenantHostelEmployee)
        .HasForeignKey<LeaveAllocation>(c => c.EmployeeId);

        builder.HasOne<LeaveRequest>(c => c.LeaveRequest)
        .WithOne(c => c.TenantHostelEmployee)
        .HasForeignKey<LeaveRequest>(c => c.RequestingEmployeeId);
    }
}

//Tenant Hostel Subscription
/*
public class TenantHostelSubscriptionConfiguration : IEntityTypeConfiguration<TenantHostelSubscription>
{
    public void Configure(EntityTypeBuilder<TenantHostelSubscription> builder)
    {
        builder.ToTable("TenantHostelSubscriptions").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("TenantHostelSubscriptionsId").ValueGeneratedOnAdd();
    }
}*/

//Room Occupant
public class RoomOccupantConfiguration : IEntityTypeConfiguration<RoomOccupant>
{
    public void Configure(EntityTypeBuilder<RoomOccupant> builder)
    {
        builder.ToTable("RoomOccupants").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("RoomOccupantId").ValueGeneratedOnAdd();
    }
}

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("TagId").ValueGeneratedOnAdd();
    }
}

public class HostelTagConfiguration : IEntityTypeConfiguration<TenantHostelTag>
{
    public void Configure(EntityTypeBuilder<TenantHostelTag> modelBuilder)
    {
        //builder.ToTable("HostelTags").HasKey(c => c.Id);
        //builder.Property(c => c.Id).HasColumnName("TagId");

        modelBuilder.HasKey(bc => new { bc.TagId, bc.TenantHostelId });

        modelBuilder
        .HasOne(c => c.Tag) //TenantHostelTag.Tag
        .WithMany(c => c.TenantHostelTag)//Tag.ICollection<TenantHostelTag>
        .HasForeignKey(x => x.Id);

        modelBuilder
        .HasOne(c => c.TenantHostel) //TenantHostelTag.TenantHostel
        .WithMany(c => c.TenantHostelTag)
        .HasForeignKey(x => x.Id);
    }
}