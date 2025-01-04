using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories;

public class UserRepository : GenericRepository<User> , IUserRepository
{
	readonly HttpContext _httpContext;
	readonly BlogAppDbContext _context;
	public UserRepository(BlogAppDbContext context , IHttpContextAccessor httpContext) : base(context)
	{
		_httpContext = httpContext.HttpContext;
		_context= context;
	}

	public async Task<User?> GetByUserNameAsync(string username)
	{
	return	await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();	
	}

	public User GetCurrentUser()
	{
		return new();
	}

	public int GetCurrentUserId()
	{
		return 0;
	}
}
