namespace MindCare.DAL.Entities;

public class Availability : BaseEntity
{
    public Guid SpecialistId { get; set; }
    public Specialist Specialist { get; set; }
    public DateOnly Date { get; set; }
    public TimeSpan Time { get; set; }
    public bool IsBooked { get; set; } = false;
}
