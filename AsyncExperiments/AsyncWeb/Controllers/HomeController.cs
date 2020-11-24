using AsyncWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Void()
        {
            var asyncVoid = new AsyncVoid();
            asyncVoid.CallAsyncVoid();
            return View();
        }

        public IActionResult Result()
        {
            var result = new Result();
            var number = result.GetNumberAsync().Result;
            return View(number);
        }

        public async Task<ActionResult> Parallelism()
        {
            var result = new Result();
            var number = await result.GetBothAsync("https://jsonplaceholder.typicode.com/todos/1", "https://jsonplaceholder.typicode.com/todos/2");
            return View(number);
        }

        public  ActionResult Deadlock()
        {
            var result = new Result();
            var number = result.DownloadStringV5("https://jsonplaceholder.typicode.com/todos/1");
            return View(number);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
