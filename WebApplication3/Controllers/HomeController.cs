using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMyDownstreamService myDownstreamService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMyDownstreamService myDownstreamService, ILogger<HomeController> logger)
        {
            this.myDownstreamService = myDownstreamService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string accessToken = myDownstreamService.CallDownstreamServiceAsync().Result;
            Debug.Write(accessToken);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}