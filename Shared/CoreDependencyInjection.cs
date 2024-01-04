using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
