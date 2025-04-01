using MindCare.BLL.DTOs;

namespace MindCare.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<IEnumerable<ReviewDto>> GetReviewsForSpecialistAsync(Guid specialistId);
        Task CreateAsync(ReviewDto reviewDto);
        Task UpdateAsync(ReviewDto reviewDto);
        Task DeleteAsync(Guid id);
    }
}
