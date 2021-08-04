using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apptest1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https") });
            builder.Services.AddHttpClient("apptest1.Api", client =>
             {
                 client.BaseAddress = new Uri("https://plannerapp-api.azurewebsites.net");
             }).AddHttpMessageHandler<AutharizationMessageHundler>();
            builder.Services.AddTransient<AutharizationMessageHundler>();
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("apptest1.Api"));
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
