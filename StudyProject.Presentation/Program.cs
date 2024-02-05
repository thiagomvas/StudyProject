using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudyProject.Application;
using StudyProject.Application.Articles.Commands;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Infrastructure;
using StudyProject.Presentation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IDatabaseContext, FirebaseContext>();
builder.Services.AddScoped<DatabaseAccess>(); 

await builder.Build().RunAsync();


public class ArrayReference<T>
{
	public readonly T[] array;
	public T this[int i]
	{
		get => array[i];
		set => array[i] = value;
	}
	public ArrayReference(T[] array)
	{
		this.array = array;
	}
}