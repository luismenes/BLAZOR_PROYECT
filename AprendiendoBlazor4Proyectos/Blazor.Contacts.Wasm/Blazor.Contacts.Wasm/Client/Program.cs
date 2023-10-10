using Blazor.Contacts.Wasm.Client;
using Blazor.Contacts.Wasm.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Agregamos la libreria
builder.Services.AddScoped<IContactService, ContactService>();

await builder.Build().RunAsync();
