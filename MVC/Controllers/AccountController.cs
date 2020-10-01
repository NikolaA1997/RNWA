using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                if (username.Equals("user") && password.Equals("user123")) {
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("role", "user");
                    return RedirectToAction("Index", "Home");
                }
                 if (username.Equals("admin") && password.Equals("admin123")) {
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("role", "admin");
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}