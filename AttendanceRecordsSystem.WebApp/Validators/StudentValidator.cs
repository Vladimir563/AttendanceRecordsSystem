using AttendanceRecordsSystem.Domain.Core;
using FluentValidation;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).Length(0, 15);
            RuleFor(x => x.LastName).Length(0, 15);
            RuleFor(x => x.StudentsGroupId).NotNull();
            RuleFor(x => x.Group).NotNull();
        }
    }
}
