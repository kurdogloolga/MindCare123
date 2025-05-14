using MindCare.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MindCare.Web.Models;
public class RegisterViewModel
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required][EmailAddress] public string Email { get; set; }
    [Required][DataType(DataType.Password)] public string Password { get; set; }
    [DataType(DataType.Password)][Compare("Password")] public string ConfirmPassword { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
}
