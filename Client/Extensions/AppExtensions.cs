using Client.Responses;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class AppExtensions
    {
        public async static Task Initialise(this IComponentsApplicationBuilder applicationBuilder)
        {
            var apiClient = applicationBuilder.Services.GetService<IApiClient>();
            var initialisation = await apiClient.GetAsync<InitialisationResponse>("api/application");
            if (IPAddress.TryParse(initialisation.IpAddress, out var address)) {
                State.GlobalState.IpAddress = address;
            }
        }
    }
}
