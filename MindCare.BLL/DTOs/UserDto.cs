using MindCare.DAL.Entities.Enums;

namespace MindCare.BLL.DTOs;
public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public UserRole Role { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
