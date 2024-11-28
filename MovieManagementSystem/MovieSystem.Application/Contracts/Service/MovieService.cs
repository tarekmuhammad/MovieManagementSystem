using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using System.Linq.Expressions;


namespace MovieSystem.Application.Contracts.Service
{
    internal class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetAllMovies()
        {
            var data = await _unitOfWork.MovieRepo.GetAsync(
                includeProperties: new List<Expression<Func<Movie, object>>>
                {
                  a => a.category,
                  a=> a.Reviews
                });
            var result = _mapper.Map<IEnumerable<MovieDetailsDto>>(data);
            return result;
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetAllWithCategory()
        {
            var data = await _unitOfWork.MovieRepo.GetAsync(
                includeProperties: new List<Expression<Func<Movie, object>>>
                {
                  a => a.category,
                  a=> a.Reviews
                });
            var result = _mapper.Map<IEnumerable<MovieDetailsDto>>(data);
            return result;
        }


        public async Task<MovieDetailsDto> GetMovie(int id)
        {
            var data = await _unitOfWork.MovieRepo.GetEntityAsync(
                criteria:a=> a.CategoryId == id,    
                includeProperties: new List<Expression<Func<Movie, object>>>
                {
                  a => a.category,
                  a=> a.Reviews
                });
            var result = _mapper.Map<MovieDetailsDto>(data);
            return result;
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetMovieByCategory(int catId)
        {
             var data = await _unitOfWork.MovieRepo.GetAsync(criteria: x=> x.CategoryId == catId,
                includeProperties: new List<Expression<Func<Movie, object>>>
                {
                  a => a.category,
                  a=> a.Reviews
                });
            var result = _mapper.Map<IEnumerable<MovieDetailsDto>>(data);
            return result;
        }


        public async Task CreateMovie(MovieCreateDto model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                model.EnteredBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Movie>(model);
                await _unitOfWork.MovieRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task UpdateMovie(MovieUpdateDto model)
        {
            try
            {
                var q = _unitOfWork.MovieRepo.GetById(model.Id);
                var EntryDate = q.EntryDate;
                var EntryBy = q.EnteredBy;

                model.EnteredBy = EntryBy;
                model.EntryDate = EntryDate;
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Movie>(model);
                 _unitOfWork.MovieRepo.Update(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task DeleteMovie(MovieDeleteDto model)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Movie>(model);
                _unitOfWork.MovieRepo.Delete(result);
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
