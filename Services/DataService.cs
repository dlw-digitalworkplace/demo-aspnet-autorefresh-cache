using Microsoft.Extensions.Caching.Memory;

namespace Demo.AutoRefreshCache.Services
{
	public interface IDataService
	{
		string GetData();

		void UpdateData();
	}

	public class DataService : IDataService
	{
		private readonly IMemoryCache _cache;

		private const string CACHEKEY = "data-cache-key";

		public DataService(IMemoryCache cache)
		{
			_cache = cache;
		}

		public string GetData()
		{
			if (_cache.TryGetValue<string>(CACHEKEY, out var data))
			{
				return data!;
			}

			UpdateData();

			return GetData();
		}

		public void UpdateData()
		{
			var data = DateTime.UtcNow.ToString();

			_cache.Set(CACHEKEY, data, DateTimeOffset.Now + TimeSpan.FromSeconds(60));
		}
	}
}
