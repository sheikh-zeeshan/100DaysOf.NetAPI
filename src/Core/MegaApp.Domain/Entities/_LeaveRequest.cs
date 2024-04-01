using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

public class LeaveRequest : BaseEntity //<int>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public byte[] RowVersion { get; set; }

    //Referece types

    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    [ForeignKey("RequestingEmployeeId")]
    public TenantHostelEmployee TenantHostelEmployee { get; set; }

    public int RequestingEmployeeId { get; set; }
}