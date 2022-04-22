using Fluxor;
using Fluxor.Blazor.Web.Components;
using Fluxor.Blazor.Web.Middlewares.Routing;
using Microsoft.AspNetCore.Components;
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
		[Inject]
		private IState<CounterState> CounterState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private bool isAutoCancel = true;
		private CancellationTokenSource cancellationTokenSource;

		private void OnIncrement()
		{
			cancellationTokenSource = new();
			Dispatcher.Dispatch(new CounterAction(1, cancellationTokenSource.Token));

			if (isAutoCancel)
			{
				cancellationTokenSource.Cancel();
			}

			cancellationTokenSource.Dispose();
		}
	}
}
