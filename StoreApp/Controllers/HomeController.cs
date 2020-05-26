using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
