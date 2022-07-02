using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Business;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories;
using AttendanceRecordsSystem.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AttendanceRecordsSystem.WebApp.Registrators
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services.AddScoped<IReport, JsonReport>()
                           .AddScoped<IReport, XmlReport>()
                           .AddScoped<IUnitOfWork, EFUnitOfWork>();
                           
        }
    }
}
