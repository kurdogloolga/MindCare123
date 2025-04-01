using MindCare.DAL.Entities;

namespace MindCare.DAL.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(Guid id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetReviewsForSpecialistAsync(Guid specialistId);
        Task AddAsync(Review review);
        void Update(Review review);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
