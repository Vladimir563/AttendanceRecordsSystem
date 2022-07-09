using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Business;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories;
using AttendanceRecordsSystem.Services;
using Microsoft.Extensions.DependencyInjection;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Extensions.Registrators
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services.AddScoped<IReportGenerator<Report>, ReportGenerator>()
                           .AddScoped<IUnitOfWork, EFUnitOfWork>();
                           
        }
    }
}
