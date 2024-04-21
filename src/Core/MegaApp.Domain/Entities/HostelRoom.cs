using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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

    public int TenantId
    {
        get; set;
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}

//rooms has 0 or more occuptant