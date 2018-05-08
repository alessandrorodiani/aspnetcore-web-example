using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyDemoApp.Data;
using MyDemoApp.Models;

namespace MyDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccessRepository _accessRepository;

        public HomeController(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [HttpGet]
        [ActionName("Login")]
        public IActionResult Login_Get()
        {
            ViewData["Message"] = "My login";
            return View("Login");
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login_Post(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View("Login", loginModel);

            var loginResult = _accessRepository.Login(loginModel.EmailAddress, loginModel.Password);
            if (loginResult)
                return RedirectToAction("Logged");

            ViewData["ErrorMessage"] = "Invalid credentials";
            return View("Login");
        }

        public IActionResult Logged()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
