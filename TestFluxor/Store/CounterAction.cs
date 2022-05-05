using Fluxor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestFluxor.Store
{
	public class CounterAction
	{
		public int Value { get; }

		public CounterAction(int value)
		{
			Value = value;
		}

		private static class Reducers
		{
			[ReducerMethod]
			public static CounterState Reduce(CounterState counterState, CounterAction counterAction) =>
				counterState with
				{
					Value = counterAction.Value,
				};
		}
	}
}
