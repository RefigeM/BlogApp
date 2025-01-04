namespace BlogApp.BL.DTOs.Options;

public class JwtOptions
{
	public static string Jwt = "JwtOptons";
	public string Issuer { get; set; }
	public string Audience { get; set; }
	public string SecretKey { get; set; }
}
