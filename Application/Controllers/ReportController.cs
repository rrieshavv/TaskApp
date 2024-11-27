using Application.Lib;
using Application.Models.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Services.Services.Report;

namespace Application.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Transfers(string fromdate = "", string todate = "")
        {

            if (!string.IsNullOrEmpty(fromdate) && !string.IsNullOrEmpty(todate))
            {
                var result = await _reportService.GetTransferResponse(User.Identity.Name, fromdate, todate);

                if (result.Any())
                {
					if (result.FirstOrDefault().Code == 0)
					{
						var response = result.MapObjects<TransferData>();

						var tranferViewModel = new TransferReportViewModel
						{
							TransferData = response
						};

						TempData["success"] = result.FirstOrDefault().Message;
						return View(tranferViewModel);
					}
				}

                TempData["result"] = "No transfers found.";
                return View();
            }

            return View();
        }
    }
}
