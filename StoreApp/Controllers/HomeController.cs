using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace StoreApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {       
        public IActionResult Index()
        {
            ViewBag.sessionUserName = HttpContext.Session.GetString("username");
            return View();          
        }
    }
}
