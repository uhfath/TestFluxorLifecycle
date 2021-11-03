using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFluxor.Actions;
using TestFluxor.States;

namespace TestFluxor.Pages
{
	public partial class Counter : FluxorComponent
	{
		[Inject]
		private IState<CounterState> CounterState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private int _internalCounterValue;

		private async Task InvokeCallbackAsync()
		{
			Console.WriteLine("DISPATCH_START_QUERY");
			Dispatcher.Dispatch(new StartQueryCounterAction());
			Console.WriteLine("DISPATCHED_START_QUERY");

			var value = await CounterState.Value.CounterTask;
			_internalCounterValue = value;
			Console.WriteLine("DISPATCH_START_QUERY_RESULT: {0}", _internalCounterValue);

			Console.WriteLine("DISPATCH_FINISH_QUERY");
			Dispatcher.Dispatch(new FinishQueryCounterAction());
			Console.WriteLine("DISPATCHED_FINISH_QUERY");
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await InvokeCallbackAsync();
				StateHasChanged();
			}

			await base.OnAfterRenderAsync(firstRender);
		}
	}
}
