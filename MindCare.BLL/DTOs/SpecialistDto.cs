namespace MindCare.BLL.DTOs;
public class SpecialistDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal PricePerSession { get; set; }
    public decimal Rating { get; set; }
}
