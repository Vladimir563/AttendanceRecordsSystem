using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceRecordsSystem.WebApp.Registrators
{
    public static class RepositoriesRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IRepository<Student>, StudentsRepository>()
                           .AddScoped<IRepository<Lector>, LectorsRepository>()
                           .AddScoped<IRepository<Lection>, LectionsRepository>()
                           .AddScoped<IRepository<StudentsGroup>, StudentsGroupsRepository>();

        }
    }
}
