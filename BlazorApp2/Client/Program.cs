global using BlazorApp2.Shared;
global using BlazorApp2.Client.Services.SinhvienServices;

using BlazorApp2.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp2.Client.Services.SinhvienServices;
using MudBlazor.Services;

namespace Company.WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddMudServices();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("BlazorApp2.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorApp2.ServerAPI"));
            builder.Services.AddScoped<ISinhvientrungtuyen, Sinhvientrungtuyen> ();
            builder.Services.AddApiAuthorization(); 

            await builder.Build().RunAsync();
        }
    }
}