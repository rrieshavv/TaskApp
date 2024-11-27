using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text;
using TaskApp.Services.Models;
using TaskApp.Services.Services.ExchangeRate;
using TaskApp.Services.Services.Transfer;

namespace Application.Controllers
{
	[Authorize]
	public class TransferController : Controller
	{
		private readonly ItransferService _transferService;
		private readonly IExchangeRateService _exchangeRateService;

		public TransferController(ItransferService transferService, IExchangeRateService exchangeRateService)
		{
			_transferService = transferService;
			_exchangeRateService = exchangeRateService;
		}


		public async Task<IActionResult> Index()
		{
			var model = new TransferViewModel
			{
				senderInfo = await renderTransferView(),
				paymentDetail = new PaymentDetail
				{
					ExchangeRate = await getExchangeRate("MYR")
				}
			};


			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(TransferViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.senderInfo = await renderTransferView();
				return View(model);
			}

			try
			{
				var reqModel = new TransferModel
				{
					UserEmail = User.Identity.Name,
					Firstname = model.receiverInfo.Firstname,
					Middlename = model.receiverInfo.Middlename,
					Lastname = model.receiverInfo.Lastname,
					Address = model.receiverInfo.Address,
					Country = model.receiverInfo.Country,
					BankName = model.paymentDetail.BankName,
					AccountNumber = model.paymentDetail.AccountNumber,
					TransferAmount = decimal.Parse(model.paymentDetail.TransferAmount),
					ExchangeRate = decimal.Parse(await getExchangeRate("MYR")),
					TransferIso3 = "MYR", //Malaysian
					PayoutIso3 = "NPR"
				};

				reqModel.PayoutAmount = reqModel.TransferAmount * reqModel.ExchangeRate;

				var response = await _transferService.TransferMoney(reqModel);
				TempData["transferSuccess"] = $"{response.Message}. Transfer ID: {response.TransferId}";
			}
			catch(Exception ex)
			{
				model.senderInfo = await renderTransferView();
				TempData["error"] = "Transfer failed.";
				return View(model);
			}

			return Redirect("/");
		}

		async Task<SenderInfo> renderTransferView()
		{
			var senderInfoResult = await _transferService.GetDetailsByEmailAsync(User.Identity.Name);
			var senderinfo = new SenderInfo
			{
				Firstname = senderInfoResult.Firstname,
				Middlename = senderInfoResult.Middlename,
				Lastname = senderInfoResult.Lastname,
				Address = senderInfoResult.Address,
				Country = senderInfoResult.Country,
			};
			return senderinfo;
		}

		async Task<string> getExchangeRate(string iso3)
		{
			var exhangeRate = await _exchangeRateService.GetExchangeRateByIso3(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), iso3);
			return exhangeRate.Sell;
		}
	}
}
