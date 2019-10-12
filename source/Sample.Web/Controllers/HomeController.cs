using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpcontext, IActivityAccessor activityAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpcontext;
            _activityAccessor = activityAccessor;
        }

        public IActionResult Index()
        {
            return View();
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
