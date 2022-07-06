using AttendanceRecordsSystem.Infrastructure.Data;
using AttendanceRecordsSystem.WebApp.Registrators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using AttendanceRecordsSystem.WebApp.Authentication;
using System.Text;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AttendanceRecordsSystemContext>();

            services.AddServices()
                    .AddRepositories()
                    .AddValidators();

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers();

            IConfigurationSection settingsSection = Configuration.GetSection("AppSettings");
            AppSettings settings = settingsSection.Get<AppSettings>();
            byte[] signingKey = Encoding.UTF8.GetBytes(settings.EncryptionKey);
            services.AddAuthentication(signingKey);

            services.AddSwaggerDocumentation();

            services.Configure<AppSettings>(settingsSection);
            services.AddTransient<UserRepository>();
            services.AddTransient<UserService>();
            services.AddTransient<AuthenticationService>();
            services.AddTransient<TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AttendanceRecordsSystemContext context)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerDocumentation();
        }
    }
}
