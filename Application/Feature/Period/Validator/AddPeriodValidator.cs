
using FluentValidation;

namespace Application.Feature
{
    public class PeriodValidation : AbstractValidator<PeriodCommand>
    {
        public PeriodValidation()
        {
            RuleFor(e => e.EndDate).GreaterThan(e => e.BeginDate);
            RuleFor(e => e.EndDate).GreaterThan(DateTimeOffset.Now);
            RuleFor(e => e.Description).MaximumLength(200);
        }
    }
}
