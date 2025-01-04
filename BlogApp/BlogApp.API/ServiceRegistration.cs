using BlogApp.BL.DTOs.Options;
using FluentAssertions.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApp.API
{
    public static  class ServiceRegistration
    {
		public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration Configuration)
		{
			services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));
			return services;
		}
		public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration Configuration)
		{
			JwtOptions opt = new JwtOptions();
			opt.Issuer = Configuration.GetSection("JwtOptions")["Issuer"]!;
			opt.Audience = Configuration.GetSection("JwtOptions")["Audience"]!;
			opt.SecretKey = Configuration.GetSection("JwtOptions")["SecretKey"]!;
			var singInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
				opt.TokenValidationParemetrs = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,


					IssuerSigningKey = singInKey,
					ValidAudience = jwtOpt.Audience,
					ValidIssuer= jwtOpt.Issuer,
					ClockSkew = TimeSpan.Zero
				};
			});
			return services;
		}
	}
}
