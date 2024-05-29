using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("Tenants")]
public class Tenant : BaseEntity //<int>
{
    // public override string ToString()
    // {
    //     return JsonSerializer.Serialize(this);
    // }
    public Tenant()
    {
        Address = new Address();
    }
    public string TenantName { get; set; }
    public string Description { get; set; }


    public string Email { get; set; }

    public string Phone { get; set; }

    [NotMapped]
    public List<string> Phones { get; set; }

    public List<TenantHostel> TenantHostels { get; set; }

    public Address Address { get; set; }

    public AppUser AppUser { get; set; }
}