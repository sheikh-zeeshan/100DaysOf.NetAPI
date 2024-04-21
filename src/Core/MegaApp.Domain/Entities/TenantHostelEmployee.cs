using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("TenantHostelEmployees")]
public class TenantHostelEmployee : AuditableEntity //<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsDeleted { get; set; }

    public int TenantHostelId { get; set; }

    [ForeignKey("TenantHostelId")]
    public TenantHostel TenantHostel { get; set; }

    public LeaveAllocation LeaveAllocation { get; set; }
    public LeaveRequest LeaveRequest { get; set; }

    public int TenantId { get; set; }

    //Reference types
    // public LeaveAllocation LeaveAllocation { get; set; }

    // public LeaveRequest LeaveRequest { get; set; }
}