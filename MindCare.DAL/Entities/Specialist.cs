namespace MindCare.DAL.Entities
{
    public class Specialist
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Description { get; set; }

        public string Specialization { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerSession { get; set; }

        public decimal Rating { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
