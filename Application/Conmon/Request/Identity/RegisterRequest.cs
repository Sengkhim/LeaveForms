using Domain.Enumerable;
using FluentValidation;
using Presistance.DataBase;
using System.ComponentModel.DataAnnotations;

namespace Application.Conmon.Request.Identity
{
    public class RegisterRequest
    {
        [Required] [EmailAddress] public string? Email { get; set; }
        [Required] [MinLength(6)] public string? Password { get; set; }

        [Required] [Compare("Password")] public string? ConfirmPassword { get; set; }

        [Required] public string? PhoneNumber { get; set; }

        public bool ActivateUser { get; set; } = true;
        public bool AutoConfirmEmail { get; set; } = false;
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly IDataContext _context;
        private readonly IServiceProvider service;

        public RegisterRequestValidator(IServiceProvider service, IDataContext context)
        {
            this.service = service;
            _context = context;
            RuleFor(Q => Q.Email).NotEmpty().WithMessage("email can not be null").EmailAddress().MaximumLength(255)
                .Must(BeUniqueEmail).WithMessage("Email address is already registered.");
        }

        public RegisterRequestValidator()
        {
            RuleFor(e => e.Password).NotEmpty();
            RuleFor(e => e.ConfirmPassword).Equal(x => x.Password).WithMessage("Password doesn't match!");
        }

        private bool BeUniqueEmail(string email)
        {
            var exist = _context.Users.Any(Q => Q.Email == email);
            return exist == false;
        }
    }
}
