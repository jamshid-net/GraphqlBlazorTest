using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphqlBlazorTest.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GraphqlBlazorTest.Client;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");


        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services
        .AddProjectClient()
        .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7255/graphql"));

        builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient("https://localhost:7255/graphql", new NewtonsoftJsonSerializer()));

        await builder.Build().RunAsync();
    }
}
