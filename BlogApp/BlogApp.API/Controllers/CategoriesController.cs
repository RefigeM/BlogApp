using BlogApp.BL.DTOs.CategoryDTOs;
using BlogApp.BL.Services.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.BL.DTOs.UserDTOs;
using BlogApp.BL.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController(ICategoryService _service) : ControllerBase
	{
		[HttpGet("[action]")]
		public async Task<IActionResult> Byte(string value)
		{
			return Ok(HashHelper.HashPassword(value));
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> Verify(string hash, string password)
		{
			return Ok(HashHelper.VerifyHashedPassword(hash, password));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Get() 
		{
			return Ok(await _service.GetAllAsync());
		}
		[HttpPost]
		public async Task<IActionResult> Post(CategoryCreateDto dto)
		{
			return Ok(await _service.CreateAsync(dto));
		}
	}
}
