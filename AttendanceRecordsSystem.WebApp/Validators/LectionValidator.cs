using AttendanceRecordsSystem.Domain.Core;
using FluentValidation;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Validators
{
    public class LectionValidator : AbstractValidator<Lection>
    {
        public LectionValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("You must set lection's {PropertyName}");
            RuleFor(x => x.Date).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage("Lection's {PropertyName} shouldn't be empty");
            RuleFor(x => x.LectorId).NotNull();
            RuleFor(x => x.Lector).NotNull().WithMessage("Lection must have a Lector");
            RuleFor(x => x.Tittle).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(30);
        }
    }
}
