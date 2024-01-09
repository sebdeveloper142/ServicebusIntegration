using Microsoft.Extensions.DependencyInjection;
using Shared.Client;
using Shared.Repositories;

namespace Shared
{
    public static class CoreDependencyInjection
    {

        public static void InjectCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IEvaRepository, EvaRepository>();
            services.AddHttpClient<IReceiverClient, ReceiverClient>();



        }
    }
}
