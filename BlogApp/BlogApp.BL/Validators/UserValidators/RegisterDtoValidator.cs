using BlogApp.BL.DTOs.UserDTOs;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using FluentValidation;

namespace BlogApp.BL.Validators.UserValidators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
	readonly IUserRepository _repo;
	public RegisterDtoValidator(IUserRepository repo)
	{

		_repo = repo;
		RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull()
			.EmailAddress();
		RuleFor(x => x.Username)
			.NotNull()
			.NotEmpty();
			//.Must(x => _repo.GetByUserNameAsync(x).Result == null)
			//	.WithMessage("Username exist");
	}
}
