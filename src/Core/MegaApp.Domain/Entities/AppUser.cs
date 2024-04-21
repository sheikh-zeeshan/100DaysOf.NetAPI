using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("AppUsers")]
public class AppUser : BaseEntity //<int>
{
    //public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNo { get; set; }
    public string UserName { get; set; }

    public Guid Version { get; set; }

    public Tenant Tenant { get; set; }

    [ForeignKey("Tenant")]
    public int? TenantId { get; set; }

    public int? RoleValue { get; set; }
}


public enum AppRoles
{
    SuperAdmin = 0,
    TenantOwner = 1,
    TenantUser = 2,
    ApplicationUser = 4,

}