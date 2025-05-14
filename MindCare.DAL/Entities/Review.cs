namespace MindCare.DAL.Entities;
public class Review : BaseEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid SpecialistId { get; set; }
    public Specialist Specialist { get; set; }
}
