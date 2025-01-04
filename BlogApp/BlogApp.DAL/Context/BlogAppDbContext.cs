using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Context;

public class BlogAppDbContext : DbContext
{
	public BlogAppDbContext(DbContextOptions opt) : base(opt)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogAppDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
	public DbSet<Category> Categories { get; set; }
	public DbSet<User> Users { get; set; }

}
