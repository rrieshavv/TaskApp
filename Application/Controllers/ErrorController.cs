using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
