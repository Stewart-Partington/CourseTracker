using CourseTracker.Domain.Students;
using CourseTracker.UI.Models;
using CourseTracker.UI.Services.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseTracker.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IApiDal _dal;

		public HomeController(ILogger<HomeController> logger, IApiDal dal)
		{
			_logger = logger;
			_dal = dal;
		}

		public async Task<IActionResult> Index()
		{

			var students = await _dal.GetStudents();

			return View();

		}

	}
}
