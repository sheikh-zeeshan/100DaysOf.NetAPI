using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("AppAddresses")]
public class Address : BaseEntity//<int>
{
    public string City { get; set; }
    public string State { get; set; } //Provice/Country
    public string ZipCode { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    public int AddressTypeId { get; set; }

    [ForeignKey("ParentId")]
    public Tenant Tenant { get; set; }

    public int ParentId { get; set; }
}

[Flags] //for bitwise operations
public enum AddressType
{
    Tenant = 0,
    TenantEmployee = 1,
    Hostel = 2,
    RoomOccupant = 3,
}