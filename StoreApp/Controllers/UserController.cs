using StoreApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private StoreContext db;
        public UserController(StoreContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {            
            var users = db.Users;
            ViewBag.sessionUserName = HttpContext.Session.GetString("username");
            return View(users);
        }

        public async Task<IActionResult> Delete(long? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {            
            var product = await db.Users.FindAsync(id);
            db.Users.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}

