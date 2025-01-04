using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories;

public class GenericRepository<T>(BlogAppDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
{

	protected DbSet<T> Table=_context.Set<T>();

	public async Task AddAsync(T entity)
	{
		await Table.AddAsync(entity);
	}

	public void Delete(T entity)
	{
		Table.Remove(entity);
	}

	public async Task DeleteAsync(int id)
	{
		await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
		
	}

	public IQueryable<T> GetAll() 
	{
	return	Table.AsQueryable();
	}

	public async Task<T?> GetByIdAsync(int id) 
	{
		return await Table.FindAsync(id);
	}

	public IQueryable<T> GetWhere(Func<T, bool> expression) {
	return	Table.Where(expression).AsQueryable();
	}

	public async Task<bool> IsExistAsync(int id)
	{
	return	await Table.AnyAsync(t => t.Id == id);
	}

	public async Task<int> SaveAsync()
	{
		return await _context.SaveChangesAsync();
	}
}


