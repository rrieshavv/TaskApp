using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskApp.Services.Services.ExchangeRate;

namespace Application.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IExchangeRateService _exchangeRateService;

		public HomeController(ILogger<HomeController> logger, IExchangeRateService exchangeRateService)
		{
			_logger = logger;
			_exchangeRateService = exchangeRateService;
		}

		[Authorize]
		public async Task<IActionResult> Index()
		{
			var rates = await _exchangeRateService.GetExchangeRatesAsync(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));

			var viewmodel = new HomeViewModel
			{
				exchangeRates = rates
			};

			return View(viewmodel);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}