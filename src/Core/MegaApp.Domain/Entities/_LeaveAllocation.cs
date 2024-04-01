using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

public class LeaveAllocation : BaseEntity //<int>
{
    public int NumberOfDays { get; set; }

    public int Period { get; set; }

    //Reference types

    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    [ForeignKey("EmployeeId")]
    public TenantHostelEmployee TenantHostelEmployee { get; set; }

    public int EmployeeId { get; set; }
}