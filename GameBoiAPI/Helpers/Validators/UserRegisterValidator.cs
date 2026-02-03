using FluentValidation;
using GameBoi.Models.Layer.DTOs;
using GameBoi.Services.Layer.Services.Interfaces;

namespace GameBoiAPI.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {        
        public UserRegisterValidator(IUserService userService)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress()
                                 .MustAsync(async (email, ct) => !await userService.EmailExists(email)).WithMessage("Email already exists");
            RuleFor(x => x.Username).NotEmpty()
                                    .MustAsync(async (username, ct) => !await userService.UsernameExists(username)).WithMessage("Username already exists");
            RuleFor(x => x.Password).Length(8,18).NotEmpty();
            RuleFor(x => x.ReTypePassword).NotEmpty().Equal(x => x.Password);
            RuleFor(x => x.DateOfBirth).Must(BeAtLeast18yOld).NotEmpty();
        }

        private bool BeAtLeast18yOld(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if(dateOfBirth > today.AddYears(-age))
            {
                age--;
            }
            return age > 18;
        }
    }
}
