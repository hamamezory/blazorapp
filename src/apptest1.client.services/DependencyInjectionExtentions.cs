
using Microsoft.Extensions.DependencyInjection;
using apptest1.client.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apptest1.client.services
{
    public static class DependencyInjectionExtentions
    {

        public static IServiceCollection AddHttpClientServices(this IServiceCollection services)
        {
            return services.AddScoped<iAuthenticationServices, HttpAuthenticationService>();
                           
        }
    }
}
