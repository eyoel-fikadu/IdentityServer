using IdentityServer.API.Context.Implementation;
using IdentityServer.API.Context.Interface;
using IdentityServer.Model.DomainModels;
using IdentityServer.Persistance.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IdentityServer.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("IdentityServerDatabase");
            var migrationAssembly = Assembly.GetExecutingAssembly().GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            });


            services.AddScoped<IUserManagerContext, UserManagerContext>();
            return services;
        }
    }
}
