using System.ComponentModel.DataAnnotations.Schema;

using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

[Table("RoomOccupants")]
public class RoomOccupant : AuditableEntity //<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Description { get; set; }

    [ForeignKey("HostelRoom")]
    public int? HostelRoomId { get; set; }

    public HostelRoom HostelRoom { get; set; }
}

//rooms has 0 or more occuptant