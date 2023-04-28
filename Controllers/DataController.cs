using Demo.AutoRefreshCache.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.AutoRefreshCache.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly IDataService _dataService;

		public DataController(IDataService dataService)
		{
			_dataService = dataService;
		}

		[HttpGet]
		public string Get()
		{
			return _dataService.GetData();
		}
	}
}