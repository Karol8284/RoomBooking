using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoomBooking.HybridApp.Shared.Services;
using RoomBooking.HybridApp.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the RoomBooking.HybridApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
