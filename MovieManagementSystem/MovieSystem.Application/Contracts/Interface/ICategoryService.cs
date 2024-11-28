using MovieSystem.Application.DTO;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDetailsDto>> GetAllCategories();
        Task<CategoryDetailsDto> GetCategoryById(int id);
        Task CreateParentCategory(ParentCategoryDto model);
        Task CreateSubCategory(SubCategoryDto model);
        Task UpdateCategory(CategoryUpdateDto model);
        Task DeleteCategory(int id);
    }
}
