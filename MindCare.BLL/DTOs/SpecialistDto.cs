namespace MindCare.BLL.DTOs
{
    public class SpecialistDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Specialization { get; set; }
        public string ImageUrl { get; set; }
        public decimal PricePerSession { get; set; }
        public float Rating { get; set; }
    }
}
