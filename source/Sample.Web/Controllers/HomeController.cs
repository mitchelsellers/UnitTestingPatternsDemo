using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ICG.AspNetCore.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Web.Models;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActivityAccessor _activityAccessor;
        private readonly ITimeProvider _timeProvider;

        public HomeController(ILogger<HomeController> logger, 
            IHttpContextAccessor httpcontext, 
            IActivityAccessor activityAccessor, 
            ITimeProvider timeProvider)
        {
            _logger = logger;
            _httpContextAccessor = httpcontext;
            _activityAccessor = activityAccessor;
            _timeProvider = timeProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CurrentTime()
        {
            return View(new CurrentTimeModel {CurrentTime = DateTime.Now});
        }

        public IActionResult CurrentTimeTestable()
        {
            var model = new CurrentTimeModel {CurrentTime = _timeProvider.Now};
            return View("CurrentTime", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = _activityAccessor.Current?.Id ?? _httpContextAccessor.HttpContext.TraceIdentifier });
        }
    }
}
