using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("TenantHostels")]
public class TenantHostel : AuditableEntity //<int>
{
    public string Name { get; set; }
    public bool IsPaid { get; set; }

    public Tenant Tenant { get; set; }

    [ForeignKey("Tenant")]
    public int? TenantId { get; set; }

    public List<TenantHostelEmployee> TenantHostEmployees { get; set; }

    public List<HostelRoom> HostelRooms { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public ICollection<TenantHostelTag> TenantHostelTag { get; set; }
}