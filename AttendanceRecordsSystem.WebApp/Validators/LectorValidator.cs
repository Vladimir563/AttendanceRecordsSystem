using AttendanceRecordsSystem.Domain.Core;
using FluentValidation;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Validators
{
    public class LectorValidator : AbstractValidator<Lector>
    {
        public LectorValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).Length(0, 15);
            RuleFor(x => x.LastName).Length(0, 15);
            RuleFor(x => x.Patronymic).Length(0, 15);
            RuleForEach(x => x.Lections).NotNull();
        }
    }
}
