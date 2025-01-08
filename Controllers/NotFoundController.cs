using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class NotFoundController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
