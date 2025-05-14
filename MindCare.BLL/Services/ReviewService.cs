using MindCare.BLL.Abstraction;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Services;
public class ReviewService : IReviewService
{

    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return _unitOfWork.Reviews.GetAll();
    }

    public async Task<Review> GetReviewByIdAsync(Guid id)
    {
        return await _unitOfWork.Reviews.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetReviewsBySpecialistAsync(Guid specialistId)
    {
        return _unitOfWork.Reviews.GetAll().Where(r => r.SpecialistId == specialistId);
    }

    public async Task<IEnumerable<Review>> GetReviewsByUserAsync(Guid userId)
    {
        return _unitOfWork.Reviews.GetAll().Where(r => r.UserId == userId);
    }

    public async Task<Guid> CreateReviewAsync(Review review)
    {
        await _unitOfWork.Reviews.AddAsync(review);
        await _unitOfWork.CommitAsync();
        return review.Id;
    }

    public async Task UpdateReviewAsync(Review review)
    {
        _unitOfWork.Reviews.Update(review);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        var rev = await _unitOfWork.Reviews.GetByIdAsync(id);
        _unitOfWork.Reviews.Remove(rev);
        await _unitOfWork.CommitAsync();
    }
}
