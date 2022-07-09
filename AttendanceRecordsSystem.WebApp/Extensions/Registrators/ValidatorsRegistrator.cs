using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.WebApp.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Extensions.Registrators
{
    public static class ValidatorsRegistrator
    {
        public static IServiceCollection AddValidators(this IServiceCollection services) 
        {
            return services.AddScoped<IValidator<Student>, StudentValidator>()
                    .AddScoped<IValidator<Lector>, LectorValidator>()
                    .AddScoped<IValidator<Lection>, LectionValidator>()
                    .AddScoped<IValidator<StudentsGroup>, StudentsGroupValidator>();
        }
    }
}
