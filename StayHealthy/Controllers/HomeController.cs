using StayHealthy.Common.Helpers;
using StayHealthy.Entities;
using StayHealthy.Entities.Model;
using StayHealthy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Login(LoginModel model)
        {
            var apiUrl = "api/GetUserDetail?Email=" + model.Email + "&Password=" + model.Password;
            var response = new ApiResponse<UserModel>();
            System.Diagnostics.Debug.WriteLine("Response Start");
            var result = await WebApiHelper.HttpClientRequestReponce<ApiResponse<UserModel>>(response, apiUrl);
            if (result.Success && result.Data.Count > 0)
            {
                Session["UserId"] = result.Data[0].UserId;
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Invalid Username or Password");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Registration(LoginModel model)
        {
            ModelState.Remove("Email");
            ModelState.Remove("RegistrationPassword");
            if (ModelState.IsValid)
            {
                var apiUrl = "api/RegistrationUser";
                var response = new ApiResponse<LoginModel>();
                var result = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<LoginModel>, LoginModel>(model, apiUrl);
                if (result.Success && result.Data.Count > 0)
                {
                    if (result.Data[0].UserId > 0)
                    {
                        this.AddToastMessage("Registration Successfully", "Thank you very much for joining this community...", Common.Enums.SystemEnum.ToastType.Success);
                    }
                    else
                    {
                        this.AddToastMessage("Already Email Exists", "Account associated with this email already exists.", Common.Enums.SystemEnum.ToastType.Success);
                    }
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
