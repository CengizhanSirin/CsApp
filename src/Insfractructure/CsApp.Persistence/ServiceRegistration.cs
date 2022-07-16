using CsApp.Application.Interfaces.Repository;
using CsApp.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CsApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IComplaintRepository, ComplaintRepository>();
        }
    }
}
