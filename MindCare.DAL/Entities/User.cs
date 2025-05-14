using Microsoft.AspNetCore.Identity;
using MindCare.DAL.Entities.Enums;

namespace MindCare.DAL.Entities;
public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public UserRole Role { get; set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
    public ICollection<Review> Reviews { get; private set; } = new List<Review>();
}
