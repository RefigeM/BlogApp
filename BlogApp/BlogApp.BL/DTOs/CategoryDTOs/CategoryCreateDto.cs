using BlogApp.Core.Entities;

namespace BlogApp.BL.DTOs.CategoryDTOs;

public class CategoryCreateDto
{
	public string Name { get; set; }
	public string Icon { get; set; }
	public static implicit operator Category(CategoryCreateDto dto)
	{
		Category category = new Category
		{
			Icon = dto.Icon,
			Name = dto.Name
		};
		return category;
	}

}
