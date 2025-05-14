using MindCare.DAL.Entities;

namespace MindCare.BLL.Abstraction;
public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviewsAsync();
    Task<Review> GetReviewByIdAsync(Guid id);
    Task<IEnumerable<Review>> GetReviewsBySpecialistAsync(Guid specialistId);
    Task<IEnumerable<Review>> GetReviewsByUserAsync(Guid userId);
    Task<Guid> CreateReviewAsync(Review review);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(Guid id);
}
