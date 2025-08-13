using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestTelegramApp;
using TestTelegramApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.HostEnvironment.BaseAddress;
if (builder.HostEnvironment.IsDevelopment())
    baseAddress = "/"; // Для локальной разработкиs

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
builder.Services.AddScoped<TelegramService>();

await builder.Build().RunAsync();
