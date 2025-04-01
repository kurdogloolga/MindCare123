using MindCare.DAL.Entities.Enums;

namespace MindCare.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateOnly Birthday { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
