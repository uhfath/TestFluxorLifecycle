using Fluxor;
using Fluxor.Blazor.Web.Components;
using Fluxor.Blazor.Web.Middlewares.Routing;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestFluxor.Store;

namespace TestFluxor.Pages
{
	public partial class Counter : FluxorComponent
	{
		//[Inject]
		//private IState<CounterState> CounterState { get; set; }

		//[Inject]
		//private IDispatcher Dispatcher { get; set; }

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		[Inject]
		private ILogger<Counter> Logger { get; set; }

		[Parameter]
		[SupplyParameterFromQuery]
		public string CounterValue { get; set; }

		private void SaveState()
		{
			var uri = NavigationManager.GetUriWithQueryParameters(new Dictionary<string, object>
			{
				{ nameof(CounterValue), CounterValue },
			});

			Logger.LogInformation("SAVE: {counter}", CounterValue);
			NavigationManager.NavigateTo(uri);
		}

		private void OnCounterChanged(ChangeEventArgs args)
		{
			CounterValue = args.Value?.ToString();
			SaveState();
		}

		private void NavigationManager_LocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
		{
			Logger.LogInformation("LOCATION: {counter}", CounterValue);
		}

		protected override void OnParametersSet()
		{
			base.OnParametersSet();

			Logger.LogInformation("PARAMS: {counter}", CounterValue);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Logger.LogInformation("INIT: {counter}", CounterValue);

			NavigationManager.LocationChanged += NavigationManager_LocationChanged;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			NavigationManager.LocationChanged -= NavigationManager_LocationChanged;
		}
	}
}
