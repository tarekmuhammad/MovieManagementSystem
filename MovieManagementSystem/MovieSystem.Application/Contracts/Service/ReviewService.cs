using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
 

namespace MovieSystem.Application.Contracts.Service
{
    public class ReviewService : IReviewService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<ReviewDetailsDto>> GetAllReviews()
        {
            var data = await _unitOfWork.ReviewsRepo.GetAsync(
                includeProperties: null,
                criteria: null
                );
            var result = _mapper.Map<IEnumerable<ReviewDetailsDto>>(data);
            return result;
        }

 
        public async Task CreateReview(ReviewCreateDto model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                model.EnteredBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Reviews>(model);
                await _unitOfWork.ReviewsRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task UpdateReview(ReviewUpdateDto model)
        {
            try
            {
                var q = _unitOfWork.ReviewsRepo.GetById(model.Id);
                var EntryDate = q.EntryDate;
                var EntryBy = q.EnteredBy;

                model.EnteredBy = EntryBy;
                model.EntryDate = EntryDate;
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Reviews>(model);
                _unitOfWork.ReviewsRepo.Update(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }


        public async Task DeleteReview(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Reviews>(id);
                _unitOfWork.ReviewsRepo.Delete(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

 


    }
}
