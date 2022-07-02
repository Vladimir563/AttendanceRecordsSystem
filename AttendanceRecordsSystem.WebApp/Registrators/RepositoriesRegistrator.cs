using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries;
using Microsoft.Extensions.DependencyInjection;


namespace AttendanceRecordsSystem.WebApp.Registrators
{
    /// <summary>
    /// 
    /// </summary>
    public static class RepositoriesRegistrator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
