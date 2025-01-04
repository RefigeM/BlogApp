using BlogApp.BL.DTOs.UserDTOs;

namespace BlogApp.BL.Services.Interfaces;

public interface IAuthService
{
	Task RegisterAsync(RegisterDto dto);
	Task<string> LoginAsync(LoginDto dto);

}
