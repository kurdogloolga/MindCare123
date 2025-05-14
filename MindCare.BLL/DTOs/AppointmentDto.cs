using MindCare.DAL.Entities.Enums;

namespace MindCare.BLL.DTOs;
public class AppointmentDto
{
    public Guid Id { get; set; }
    public Mode Mode { get; set; } = Mode.Offline;
    public string Reason { get; set; } = string.Empty;
    public DateTime AppointmentDateTime { get; set; }
    public Guid UserId { get; set; }
    public Guid SpecialistId { get; set; }
}
