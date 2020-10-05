using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CounterApp.Models;

namespace CounterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string button)
        {
            var likes = 0;

            if (System.IO.File.Exists("likes.txt"))
            {
                string noOfVisitors = System.IO.File.ReadAllText("likes.txt");
                likes = Int32.Parse(noOfVisitors);
            }

            var visit_text = (likes == 1 || likes == 0) ? " like" : " likes";
            ViewData["likes_txt"] = visit_text;

            ViewData["likes"] = likes;
           
            if (button == "first")
            {
                likes++;
                visit_text = (likes == 1) ? " like" : " likes";
                System.IO.File.WriteAllText("likes.txt", likes.ToString());
               ViewData["likes_txt"] = visit_text;

               ViewData["likes"] = likes;

            }
            return View();    
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
