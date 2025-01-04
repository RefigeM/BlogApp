using BlogApp.BL.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.BL.Services.Implements;

public class CategoryService(ICategoryRepository _categoryRepo) : ICategoryService
{
	public async Task<int> CreateAsync(CategoryCreateDto dto)
	{
		Category category = dto;
		await _categoryRepo.AddAsync(dto);
		await _categoryRepo.SaveAsync();
		return category.Id;


	}

	public async Task<IEnumerable<CategoryListItem>> GetAllAsync()
	{
		return await _categoryRepo.GetAll().Select(x => new CategoryListItem
		{
			Id = x.Id,
			Name = x.Name,
			Icon = x.Icon
		}).ToListAsync();
	}
}
