using MegaApp.Domain.Common;

namespace MegaApp.Domain.Entities;

public class User : BaseEntity<int>
{
    //public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

}