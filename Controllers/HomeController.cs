using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using TrainSystem.Entities;
using TrainSystem.Extensions;
using TrainSystem.Models;
using TrainSystem.Repositories;
using TrainSystem.ViewModels.Home;

namespace TrainSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string url)
        {
            LoginVM model = new LoginVM();
            model.Url = url;

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            User loggedUser = repo.FirstOrDefault(u =>
                                                u.Username == model.Username &&
                                                u.Password == model.Password);

            if (loggedUser == null)
            {
                ModelState.AddModelError("authFailed", "Authentication failed!");
                return View(model);
            }

            this.HttpContext.Session.SetObject("loggedUser", loggedUser);

            if (!string.IsNullOrEmpty(model.Url))
                return new RedirectResult(model.Url);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Index", "Home");
        }
    }
}