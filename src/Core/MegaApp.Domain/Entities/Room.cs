using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

public class Room : AuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Desciption { get; set; } = string.Empty;

}