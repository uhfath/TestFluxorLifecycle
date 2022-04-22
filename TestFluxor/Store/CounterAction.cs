using Fluxor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestFluxor.Store
{
	public class CounterAction
	{
		public int Step { get; }
		public CancellationToken CancellationToken { get; }

		public CounterAction(int step, CancellationToken cancellationToken)
		{
			Step = step;
			CancellationToken = cancellationToken;
		}

		private static class Reducers
		{
			[ReducerMethod]
			public static CounterState Reduce(CounterState counterState, CounterAction counterAction) =>
				counterState with
				{
					Value = counterState.Value + counterAction.Step,
				};
		}

		private class Effect : Effect<CounterAction>
		{
			public override async Task HandleAsync(CounterAction action, IDispatcher dispatcher)
			{
				await Task.Delay(1000, action.CancellationToken);
				throw new NotImplementedException();
			}
		}
	}
}
