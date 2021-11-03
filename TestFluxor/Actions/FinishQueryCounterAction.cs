using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFluxor.States;

namespace TestFluxor.Actions
{
	public record FinishQueryCounterAction
	{
		[ReducerMethod]
		public static CounterState Reduce(CounterState counterState, FinishQueryCounterAction setCounterAction)
		{
			Console.WriteLine("FINISH_QUERY_REDUCE");
			return counterState;
		}
	}
}
