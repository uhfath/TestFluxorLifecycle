using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFluxor.States
{
	public record CounterState
	{
		public Task<int> CounterTask { get; init; } = Task.FromResult(-1);

		private class Feature : Feature<CounterState>
		{
			public override string GetName() =>
				nameof(CounterState);

			protected override CounterState GetInitialState() =>
				new();
		}
	}
}
