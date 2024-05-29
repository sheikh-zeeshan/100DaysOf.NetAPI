using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;
using MegaApp.Domain.Entities;

namespace MegaApp.Domain.Entities;

[Table("Tags")]
public class Tag : BaseEntity
{
    public string Desciption { get; set; }

    public List<TenantHostel> TenantHostels { get; set; }
    public ICollection<TenantHostelTag> TenantHostelTag { get; set; }
}

[Table("TenantHostelTags")]
public class TenantHostelTag : BaseEntity
{
    public int TenantHostelId { get; set; }
    public TenantHostel TenantHostel { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
}