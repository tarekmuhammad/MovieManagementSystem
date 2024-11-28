using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using System.Linq.Expressions;


namespace MovieSystem.Application.Contracts.Service
{
    internal class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<CategoryDetailsDto>> GetAllCategories()
        {
            var data = await _unitOfWork.CategoryRepo.GetAsync(
                includeProperties: new List<Expression<Func<Category,object>>>
                {
                  a => a.Movies
                }
                );
            var result = _mapper.Map<IEnumerable<CategoryDetailsDto>>(data);
            return result;
        }


        public  async Task<CategoryDetailsDto> GetCategoryById(int id)
        {
            var data = await _unitOfWork.CategoryRepo.GetEntityAsync(
                    criteria: a => a.Id == id,
                    includeProperties: new List<Expression<Func<Category, object>>>
                     {
                          a => a.Movies
                     });
                    var result = _mapper.Map<CategoryDetailsDto>(data);
                    return result;
        }



        public async Task CreateParentCategory(ParentCategoryDto model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                model.EnteredBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Category>(model);
                await _unitOfWork.CategoryRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task CreateSubCategory(SubCategoryDto model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                model.EnteredBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Category>(model);
                await _unitOfWork.CategoryRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }



        public async Task UpdateCategory(CategoryUpdateDto model)
        {
            try
            {
                var q = _unitOfWork.CategoryRepo.GetById(model.Id);
                var EntryDate = q.EntryDate;
                var EntryBy = q.EnteredBy;

                model.EnteredBy = EntryBy;
                model.EntryDate = EntryDate;
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Category>(model);
                _unitOfWork.CategoryRepo.Update(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Category>(id);
                _unitOfWork.CategoryRepo.Delete(result);
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
