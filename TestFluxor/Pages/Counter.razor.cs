using Fluxor;
using Fluxor.Blazor.Web.Components;
using Fluxor.Blazor.Web.Middlewares.Routing;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFluxor.Pages
{
	public partial class Counter : FluxorComponent
	{
		[Inject]
		private IState<RoutingState> RoutingState { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Console.WriteLine("PARAM STATE: {0}", RoutingState.Value.Uri);
            Console.WriteLine("PARAM MANAGER: {0}", NavigationManager.Uri);
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            Console.WriteLine("ASYNC PARAM STATE: {0}", RoutingState.Value.Uri);
            Console.WriteLine("ASYNC PARAM MANAGER: {0}", NavigationManager.Uri);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Console.WriteLine("STATE: {0}", RoutingState.Value.Uri);
            Console.WriteLine("MANAGER: {0}", NavigationManager.Uri);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Console.WriteLine("ASYNC STATE: {0}", RoutingState.Value.Uri);
            Console.WriteLine("ASYNC MANAGER: {0}", NavigationManager.Uri);
        }
    }
}
