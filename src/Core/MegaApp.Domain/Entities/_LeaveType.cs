using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

public class LeaveType : BaseEntity //<int>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public LeaveAllocation LeaveAllocation { get; set; }

    public LeaveRequest LeaveRequest { get; set; }
}