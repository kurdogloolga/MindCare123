namespace MindCare.BLL.DTOs;
public class ReviewDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid SpecialistId { get; set; }
}
