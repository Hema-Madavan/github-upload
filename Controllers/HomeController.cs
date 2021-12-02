using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using videowebapp.Models;
using Microsoft.ApplicationInsights;

namespace videowebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TelemetryClient _aiClient;

        public HomeController(ILogger<HomeController> logger, TelemetryClient aiClient)
        {
            _logger = logger;
            _aiClient = aiClient;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Like(string button)
        {
            ViewBag.Message = "Thank you for your response";
            _aiClient.TrackEvent("LikeClicked");
            return View("Index");
        }
    }
}
