using AutoMapper;
using BlogApp.BL.DTOs.UserDTOs;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.ExternalServices.Interfaces;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.BL.Services.Implements;

public class AuthService(IUserRepository _repository, IMapper _mapper, IJwtTokenHandler _tokenHandler) : IAuthService
{
	public async Task<string> LoginAsync(LoginDto dto)
	{
		User? user = null;
		if (dto.UsernameOrEmail.Contains('@'))
		{
		user = await _repository.GetAll().Where(x => x.Email== dto.UsernameOrEmail).FirstOrDefaultAsync();
		}
		else
		{
			user = await _repository.GetAll().Where(x => x.Username == dto.UsernameOrEmail).FirstOrDefaultAsync();
		}
		if (user == null) throw new NotFoundException<User>();
		if (!HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password))
			throw new NotFoundException<User>();

		return _tokenHandler.CreateToken(user, 36);
	}

	public async Task RegisterAsync(RegisterDto dto)
	{
		var user = await _repository.GetAll().Where(x => x.Username == dto.Username || x.Email == dto.Email).FirstOrDefaultAsync();
		if (user != null)
		{
			if (user.Email == dto.Email)
				throw new ExistException<User>("Email already used by another user.");
			else if (user.Username == dto.Username)
				throw new ExistException<User>("Username already used by another user.");
		}
		user = _mapper.Map<User>(dto);
		await _repository.AddAsync(user);
		await _repository.SaveAsync();
	}
}
