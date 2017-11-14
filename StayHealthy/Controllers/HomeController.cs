using StayHealthy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StayHealthy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Stay Healthy";
            
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["GenderList"] = new List<SelectListItem>
            {
                new SelectListItem(){Value="1",Text="Male"},
                new SelectListItem(){Value="2",Text="Female"}
            };
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Registration(LoginModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
