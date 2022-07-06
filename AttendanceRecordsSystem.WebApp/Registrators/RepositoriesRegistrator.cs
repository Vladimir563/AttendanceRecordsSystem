using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Registrators
{
    public static class RepositoriesRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IQueriesRepository<Student>, StudentsQueriesRepository>()
                           .AddScoped<ICommandsRepository<Student>, StudentsCommandsRepository>()

                           .AddScoped<IQueriesRepository<Lector>, LectorsQueriesRepository>()
                           .AddScoped<ICommandsRepository<Lector>, LectorsCommandsRepository>()

                           .AddScoped<IQueriesRepository<Lection>, LectionsQueriesRepository>()
                           .AddScoped<ICommandsRepository<Lection>, LectionsCommandsRepository>()

                           .AddScoped<IQueriesRepository<StudentsGroup>, StudentsGroupsQueriesRepository>()
                           .AddScoped<ICommandsRepository<StudentsGroup>, StudentsGroupsCommandsRepository>();
        }
    }
}
