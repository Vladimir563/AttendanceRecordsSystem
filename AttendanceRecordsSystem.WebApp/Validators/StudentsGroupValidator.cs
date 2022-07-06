using AttendanceRecordsSystem.Domain.Core;
using FluentValidation;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Validators
{
    public class StudentsGroupValidator : AbstractValidator<StudentsGroup>
    {
        public StudentsGroupValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.GroupName).NotEmpty().MaximumLength(5);
            RuleForEach(x => x.Students).NotNull();
        }
    }
}
