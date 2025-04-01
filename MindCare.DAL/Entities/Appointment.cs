using MindCare.DAL.Entities.Enums;

namespace MindCare.DAL.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SpecialistId { get; set; }
        public Specialist Specialist { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AppointmentStatus Status { get; set; }

        public string Comment { get; set; }
    }
}
