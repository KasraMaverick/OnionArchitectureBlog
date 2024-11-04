using B.Application;
using B.Application.Contracts.ArticleCategory;
using B.Domain.ArticleCategoryAgg;
using B.Infrastructure.Core;
using B.Infrastructure.EfCore;
using B.Infrastructure.EfCore.Repositories;
using B.Presentation.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Net.Http.Json;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");








builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//-------------------- SERVICES --------------------\\
builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDb")));

using (var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
{
    // Fetch the JSON file as a stream
    using var stream = await httpClient.GetStreamAsync("appsettings.json");
    builder.Configuration.AddJsonStream(stream);
}
Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("BlogDb"));
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();



