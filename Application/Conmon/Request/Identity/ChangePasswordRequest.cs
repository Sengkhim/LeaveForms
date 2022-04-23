

using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Application.Conmon.Request.Identity
{
    public class ChangePasswordRequest
    {
        [Required] public string? Password { get; set; }

        [Required] public string? NewPassword { get; set; }

        [Required] public string? ConfirmNewPassword { get; set; }
    }

    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(e => e.Password).NotEmpty();
        }
    }
}
