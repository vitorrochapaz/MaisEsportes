using maisesportes.Web;
using maisesportes.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddTransient<AlunoAPI>();
builder.Services.AddTransient<ProfessorAPI>();
builder.Services.AddTransient<TurmaAPI>();

builder.Services.AddHttpClient("API", client => {
    client.BaseAddress = new Uri("https://localhost:7291/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
