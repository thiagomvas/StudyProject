using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudyProject.Application.Articles.Commands;
using StudyProject.Infrastructure;
using StudyProject.Presentation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ArticleCommandInvoker invoker = new(new ApplicationDbContext());
builder.Services.AddSingleton(invoker);

await builder.Build().RunAsync();
