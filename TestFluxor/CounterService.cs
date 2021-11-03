using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestFluxor
{
	internal class CounterService
	{
		private readonly ISessionStorageService _sessionStorageService;

		public CounterService(
			ISessionStorageService sessionStorageService)
		{
			this._sessionStorageService = sessionStorageService;
		}

		public ValueTask<int> GetCounterValueAsync(CancellationToken cancellationToken = default) =>
			_sessionStorageService.GetItemAsync<int>("counter", cancellationToken);

		public ValueTask SetCounterValue(int value, CancellationToken cancellationToken = default) =>
			_sessionStorageService.SetItemAsync("counter", value, cancellationToken);
	}
}
