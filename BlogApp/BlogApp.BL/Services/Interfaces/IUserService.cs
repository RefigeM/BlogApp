namespace BlogApp.BL.Services.Interfaces;

	public interface IUserService
{
	Task<string> CreateAsync();
	Task BlockAsync(string username);	
}
