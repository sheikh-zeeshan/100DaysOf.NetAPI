using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaApp.Persistance.Context;



public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {

        // modelBuilder.Entity<Site>().ToTable("Site");

        // modelBuilder.Entity<User>(entry =>
        // {
        //     entry.ToTable("Site", tb => tb.HasTrigger("trg_SiteUpdate"));
        // });

        modelBuilder.ToTable("Users");
        //modelBuilder.ToTable("Users", tb => tb.HasTrigger("trg_UserAdd"));



        modelBuilder.Property(b => b.Id).IsRequired();
    }


}