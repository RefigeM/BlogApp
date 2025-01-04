﻿using BlogApp.BL.DTOs.Options;
using BlogApp.BL.ExternalServices.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.BL.ExternalServices.Implements;

public class JwtTokenHandler : IJwtTokenHandler
{
	readonly JwtOptions opt;

	public JwtTokenHandler(IOptions<JwtOptions> _opt)
	{
		opt = _opt.Value;
	}

	public string CreateToken(User user, int hours =36)
	{
		List<Claim> claims = [
		new Claim(ClaimTypes.Name, user.Username),
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(ClaimTypes.Role, user.Role.ToString()),
			new Claim(ClaimTypes.GivenName, user.Name + " " + user.Surname)
		];

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
		SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
		JwtSecurityToken secToken = new(
			issuer: opt.Issuer,
			audience: opt.Audience,
			claims: claims,
			notBefore: DateTime.Now,
			expires: DateTime.Now.AddHours(hours),
			signingCredentials: cred
			);
		JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
		return handler.WriteToken(secToken);
	}
}
