using StoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var context = new StoreContext();
            var users = context.Users;
            return View(users);
        }

    }
}
