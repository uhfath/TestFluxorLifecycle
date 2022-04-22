using Fluxor;

namespace TestFluxor.Store
{
	[FeatureState]
	public record CounterState
	{
		public int Value { get; init; }
	}
}
