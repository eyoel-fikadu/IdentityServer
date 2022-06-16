using IdentityServer.API.Model;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer.API.Context
{
    public interface IConfigurationContext
    {

    }

    public class ConfigurationContext
    {
        private readonly ConfigurationDbContext configurationDbContext;

        public ConfigurationContext(ConfigurationDbContext configurationDbContext)
        {
            this.configurationDbContext=configurationDbContext;
        }
        public void saveAll()
        {
            foreach (var client in Config.Clients)
            {
                var item = configurationDbContext.Clients.SingleOrDefault(c => c.ClientName == client.ClientId);

                if (item == null)
                {
                    configurationDbContext.Clients.Add(client.ToEntity());
                }
            }

            foreach (var resource in Config.ApiResources)
            {
                var item = configurationDbContext.ApiResources.SingleOrDefault(c => c.Name == resource.Name);

                if (item == null)
                {
                    configurationDbContext.ApiResources.Add(resource.ToEntity());
                }
            }

            foreach (var scope in Config.ApiScopes)
            {
                var item = configurationDbContext.ApiScopes.SingleOrDefault(c => c.Name == scope.Name);

                if (item == null)
                {
                    configurationDbContext.ApiScopes.Add(scope.ToEntity());
                }
            }

            configurationDbContext.SaveChanges();

        }
    }
}
