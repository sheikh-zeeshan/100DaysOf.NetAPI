﻿// <auto-generated />
using System;
using MegaApp.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaApp.Persistance.Migrations
{
    [DbContext(typeof(MegaDbContext))]
    [Migration("20240414050909_finalizeDBsetup")]
    partial class finalizeDBsetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("MegaApp.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId")
                        .IsUnique();

                    b.ToTable("AppAddresses");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("AppUserId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.HostelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("HostelRoomId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifieddBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantHostelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TenantHostelId");

                    b.ToTable("HostelRooms", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Period")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("LeaveTypeId")
                        .IsUnique();

                    b.ToTable("LeaveAllocations");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestComments")
                        .HasColumnType("TEXT");

                    b.Property<int>("RequestingEmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LeaveTypeId")
                        .IsUnique();

                    b.HasIndex("RequestingEmployeeId")
                        .IsUnique();

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("LeaveTypeId");

                    b.Property<int>("DefaultDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LeaveTypes", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.RoomOccupant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("RoomOccupantId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("HostelRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifieddBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HostelRoomId");

                    b.ToTable("RoomOccupants", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TenantId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tenant", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TenantHostelId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifieddBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantHostels", (string)null);
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostelEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TenantHostelEmployeeId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifieddBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantHostelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TenantHostelId");

                    b.ToTable("TenantHostelEmployees", (string)null);
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TagTenantHostel", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantHostelsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagsId", "TenantHostelsId");

                    b.HasIndex("TenantHostelsId");

                    b.ToTable("TagTenantHostel");
                });

            modelBuilder.Entity("TenantHostelTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantHostelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TenantHostelId");

                    b.ToTable("TenantHostelTags");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.Address", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.Tenant", "Tenant")
                        .WithOne("Address")
                        .HasForeignKey("MegaApp.Domain.Entities.Address", "ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.HostelRoom", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.TenantHostel", "TenantHostel")
                        .WithMany("HostelRooms")
                        .HasForeignKey("TenantHostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantHostel");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveAllocation", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.TenantHostelEmployee", "TenantHostelEmployee")
                        .WithOne("LeaveAllocation")
                        .HasForeignKey("MegaApp.Domain.Entities.LeaveAllocation", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaApp.Domain.Entities.LeaveType", "LeaveType")
                        .WithOne("LeaveAllocation")
                        .HasForeignKey("MegaApp.Domain.Entities.LeaveAllocation", "LeaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveType");

                    b.Navigation("TenantHostelEmployee");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveRequest", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.LeaveType", "LeaveType")
                        .WithOne("LeaveRequest")
                        .HasForeignKey("MegaApp.Domain.Entities.LeaveRequest", "LeaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaApp.Domain.Entities.TenantHostelEmployee", "TenantHostelEmployee")
                        .WithOne("LeaveRequest")
                        .HasForeignKey("MegaApp.Domain.Entities.LeaveRequest", "RequestingEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveType");

                    b.Navigation("TenantHostelEmployee");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.RoomOccupant", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.HostelRoom", "HostelRoom")
                        .WithMany("RoomOccupants")
                        .HasForeignKey("HostelRoomId");

                    b.Navigation("HostelRoom");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostel", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.Tenant", "Tenant")
                        .WithMany("TenantHostels")
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostelEmployee", b =>
                {
                    b.HasOne("MegaApp.Domain.Entities.TenantHostel", "TenantHostel")
                        .WithMany("TenantHostEmployees")
                        .HasForeignKey("TenantHostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantHostel");
                });

            modelBuilder.Entity("TagTenantHostel", b =>
                {
                    b.HasOne("Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaApp.Domain.Entities.TenantHostel", null)
                        .WithMany()
                        .HasForeignKey("TenantHostelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TenantHostelTag", b =>
                {
                    b.HasOne("Tag", "Tag")
                        .WithMany("TenantHostelTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaApp.Domain.Entities.TenantHostel", "TenantHostel")
                        .WithMany("TenantHostelTag")
                        .HasForeignKey("TenantHostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("TenantHostel");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.HostelRoom", b =>
                {
                    b.Navigation("RoomOccupants");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.LeaveType", b =>
                {
                    b.Navigation("LeaveAllocation")
                        .IsRequired();

                    b.Navigation("LeaveRequest")
                        .IsRequired();
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.Tenant", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("TenantHostels");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostel", b =>
                {
                    b.Navigation("HostelRooms");

                    b.Navigation("TenantHostEmployees");

                    b.Navigation("TenantHostelTag");
                });

            modelBuilder.Entity("MegaApp.Domain.Entities.TenantHostelEmployee", b =>
                {
                    b.Navigation("LeaveAllocation")
                        .IsRequired();

                    b.Navigation("LeaveRequest")
                        .IsRequired();
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Navigation("TenantHostelTag");
                });
#pragma warning restore 612, 618
        }
    }
}
