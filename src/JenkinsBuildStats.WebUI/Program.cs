using JenkinsBuildStats.WebUI;
using JenkinsBuildStats.WebUI.ApiClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_BASE_URL"]) });

builder.Services.AddScoped<SettingsApiClient>();
builder.Services.AddScoped<BuildStatsApiClient>();

await builder.Build().RunAsync();
