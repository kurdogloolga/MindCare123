using MindCare.DAL.Entities.Enums;
using MindCare.DAL.Entities;

namespace MindCare.Web.Models;

public class AppointmentFormViewModel
{
    public Guid SpecialistId { get; set; }
    public string SpecialistName { get; set; }
    public List<Availability> AvailableSlots { get; set; } = new();
    public Mode Mode { get; set; }
    public string Reason { get; set; }
    public Guid AvailabilityId { get; set; }
}
