using AutoMapper;
using MindCare.BLL.DTOs;
using MindCare.BLL.Interfaces;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> GetByIdAsync(Guid id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Select(r => _mapper.Map<ReviewDto>(r));
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsForSpecialistAsync(Guid specialistId)
        {
            var reviews = await _reviewRepository.GetReviewsForSpecialistAsync(specialistId);
            return reviews.Select(r => _mapper.Map<ReviewDto>(r));
        }

        public async Task CreateAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            review.CreatedAt = DateTime.UtcNow;
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReviewDto reviewDto)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(reviewDto.Id);
            if (existingReview == null)
                throw new Exception("Review not found.");

            _mapper.Map(reviewDto, existingReview);
            _reviewRepository.Update(existingReview);
            await _reviewRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _reviewRepository.DeleteAsync(id);
            await _reviewRepository.SaveChangesAsync();
        }
    }
}
