using IdentityServer.API.Model;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Persistance.DatabaseContext
{
    public static class DatabaseInitializer
    {
        public static void PopulateIdentityServer(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            context.Database.Migrate();

        }
    }
}
