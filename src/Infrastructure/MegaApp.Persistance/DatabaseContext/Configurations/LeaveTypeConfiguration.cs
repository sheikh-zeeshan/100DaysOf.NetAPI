using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaApp.Persistance.DatabaseContext.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.ToTable("LeaveTypes").HasKey(c => c.Id);

        //modelBuilder.Property(c => c.Id).HasColumnName("LeaveTypeId");
        //modelBuilder.ToTable("LeaveTypes").HasKey(c => c.Id); //.HasKey(c => new { c.State, c.LicensePlate });

        builder.Property(b => b.Id).HasColumnName("LeaveTypeId").ValueGeneratedOnAdd();
        builder.Property(b => b.Name).IsRequired();

        builder.HasOne<LeaveAllocation>(c => c.LeaveAllocation)
              .WithOne(c => c.LeaveType)
              .HasForeignKey<LeaveAllocation>(c => c.LeaveTypeId);

        builder
        .HasOne<LeaveRequest>(c => c.LeaveRequest)
        .WithOne(c => c.LeaveType)
        .HasForeignKey<LeaveRequest>(c => c.LeaveTypeId);
    }
}

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {
        builder.ToTable("LeaveAllocations").HasKey(c => c.Id);
        builder.Property(b => b.Id).HasColumnName("LeaveAllocationId").ValueGeneratedOnAdd();
    }
}

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.ToTable("LeaveRequests").HasKey(c => c.Id);
        builder.Property(b => b.Id).HasColumnName("LeaveRequestId").ValueGeneratedOnAdd();
        builder.Property(a => a.RowVersion).IsRowVersion();
    }
}