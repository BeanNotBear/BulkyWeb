using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Controllers
{

	/// <summary>
	/// 
	/// </summary>
	/// <param name="logger"></param>
	public class HomeController(ILogger<HomeController> logger) : Controller
	{

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}
		//
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}