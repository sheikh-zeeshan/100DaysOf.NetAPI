using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;



public class LeaveType : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}


public class LeaveAllocation : BaseEntity<int>
{
    public int NoOfDays { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    public int Period { get; set; }
}


public class LeaveRequest : BaseEntity<int>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public LeaveType? LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public DateOnly DateRequestedOn { get; set; }
    public string RequestComments { get; set; } = string.Empty;
    public bool? Approved { get; set; }
    public bool? Cancelled { get; set; }
    public int RequestingEmpId { get; set; }

}

