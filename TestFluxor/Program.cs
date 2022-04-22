using Blazored.SessionStorage;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestFluxor
{
	public class Program
	{
		public static Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddFluxor(opts =>
			{
				opts.ScanAssemblies(typeof(Program).Assembly);
				//opts.UseReduxDevTools();
				opts.UseRouting();
			});
			builder.Services.AddScoped<CounterService>();
			builder.Services.AddBlazoredSessionStorage();

			return builder.Build().RunAsync();
		}
	}
}
