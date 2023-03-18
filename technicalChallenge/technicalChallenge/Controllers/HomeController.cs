using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using technicalChallenge.Models;

namespace technicalChallenge.Controllers
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

        public IActionResult Simplify()
        {
            return View();
        }
        public IActionResult ValidateName()
        {
            return View();
        }
        public ActionResult ValidateName(NameModel model)
        {
                
            if (model.Name == "hola")
            {
                ModelState.AddModelError("Name", "Es obligatorio el nombre.");
                return View(model);
            }
                  
            return View(model);
                
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}