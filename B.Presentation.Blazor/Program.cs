
using B.Presentation.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



using (var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
{
    // Fetch the JSON file as a stream
    using var stream = await httpClient.GetStreamAsync("appsettings.json");
    builder.Configuration.AddJsonStream(stream);
}


builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();

await builder.Build().RunAsync();



