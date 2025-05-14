namespace MindCare.DAL.Entities;
public class Specialist : BaseEntity
{
    public Specialist()
    {
        Appointments = new List<Appointment>();
        Reviews = new List<Review>();
        Availabilities = new List<Availability>();
    }
    public string FullName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal PricePerSession { get; set; }
    public decimal Rating { get; set; }

    public ICollection<Appointment> Appointments { get; private set; }
    public ICollection<Review> Reviews { get; private set; }
    public ICollection<Availability> Availabilities { get; private set; }
}
