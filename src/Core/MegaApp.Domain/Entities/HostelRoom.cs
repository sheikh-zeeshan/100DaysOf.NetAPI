using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("HostelRoom")]
public class HostelRoom : AuditableEntity //<int>
{
    public string Name { get; set; } = string.Empty;
    public string Desciption { get; set; } = string.Empty;

    public List<RoomOccupant> RoomOccupants { get; set; }

    public int TenantHostelId { get; set; }

    [ForeignKey("TenantHostelId")]
    public TenantHostel TenantHostel { get; set; }
}

//rooms has 0 or more occuptant