using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudyProject.Application.Articles.Commands;
using StudyProject.Infrastructure;
using StudyProject.Presentation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var db = new ApplicationDbContext();
await db.LoadData(builder.HostEnvironment.BaseAddress);

ArticleCommandInvoker invoker = new(db);
builder.Services.AddSingleton(invoker);

await builder.Build().RunAsync();
