using BlogApp.BL.DTOs.CategoryDTOs;

namespace BlogApp.BL.Services.Implements;

public interface ICategoryService
{
	Task<IEnumerable<CategoryListItem>> GetAllAsync();
	Task<int> CreateAsync(CategoryCreateDto dto);
}
