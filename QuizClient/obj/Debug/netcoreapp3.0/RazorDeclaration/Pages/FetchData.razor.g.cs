#pragma checksum "C:\Users\Tim\source\repos\BlazorQuiz\QuizClient\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b15ffd3d01179cbe35a5f5a09599e9a6caa215df"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace QuizClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Components.Layouts;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.JSInterop;
    using QuizClient;
    using QuizClient.Shared;
    using Models.Api;
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 39 "C:\Users\Tim\source\repos\BlazorQuiz\QuizClient\Pages\FetchData.razor"
            
    WeatherForecast[] forecasts;

    protected override async Task OnInitAsync()
    {
        //forecasts = await Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        var bob = await client.GetAsync<QuizDto[]>("api/quiz");
    }

    class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClient client { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private System.Net.Http.HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
