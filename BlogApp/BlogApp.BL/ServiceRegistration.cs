using BlogApp.BL.Services.Implements;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using BlogApp.BL.Services.Interfaces;
using BlogApp.BL.ExternalServices.Interfaces;
using BlogApp.BL.ExternalServices.Implements;

namespace BlogApp.BL
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddServices(this IServiceCollection service) 
		{
			service.AddScoped<ICategoryService, CategoryService>();
			service.AddScoped<IUserService, UserService>();
			service.AddScoped<IAuthService, AuthService>();
			service.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
			return service;
		}
		public static IServiceCollection AddFluentValidation(this IServiceCollection services)
		{
			services.AddFluentValidationAutoValidation();
			services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
			return services;
		}
		public static IServiceCollection AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(ServiceRegistration));
			return services;
		}
	}
}
