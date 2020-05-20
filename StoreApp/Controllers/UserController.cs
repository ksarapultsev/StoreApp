using StoreApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<IActionResult> Delete(long? id)
        {
            var storeContext = new StoreContext();
            if (id == null)
            {
                return NotFound();
            }

            var product = storeContext.Users.FirstOrDefault(m => m.UserId == id);
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
            var storeContext = new StoreContext();
            var product = await storeContext.Users.FindAsync(id);
            storeContext.Users.Remove(product);
            await storeContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}

