using MindCare.DAL.Entities.Enums;

namespace MindCare.DAL.Entities;
public class Appointment : BaseEntity
{
    public Mode Mode { get; set; } = Mode.Offline;
    public string Reason { get; set; } = string.Empty;
    public DateTime AppointmentDateTime { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid SpecialistId { get; set; }
    public Specialist Specialist { get; set; }
}
