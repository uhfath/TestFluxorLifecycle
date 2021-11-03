using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFluxor.States;

namespace TestFluxor.Actions
{
	public record StartQueryCounterAction
	{
		protected readonly TaskCompletionSource<int> CounterValueSource = new(TaskCreationOptions.RunContinuationsAsynchronously);

		[ReducerMethod]
		public static CounterState Reduce(CounterState counterState, StartQueryCounterAction refreshCurrentCounter)
		{
			Console.WriteLine("START_QUERY_REDUCE");
			return counterState with
			{
				CounterTask = refreshCurrentCounter.CounterValueSource.Task,
			};
		}

		private class Effect : Effect<StartQueryCounterAction>
		{
			public override async Task HandleAsync(StartQueryCounterAction action, IDispatcher dispatcher)
			{
				Console.WriteLine("START_QUERY_EFFECT");
				await Task.Delay(1000);

				Console.WriteLine("START_QUERY_EFFECT_RESULT");
				action.CounterValueSource.SetResult(10);
				Console.WriteLine("START_QUERY_EFFECT_RESULT_AWAITED");
			}
		}
	}
}
