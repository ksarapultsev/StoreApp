using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            var context = new StoreContext();
            var category = context.Groups;
            return View(category);
        }



        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create

        [HttpPost]
        public async Task<IActionResult> Create([Bind("GroupName, Description, RecordDateTimeStamp ")] Group group)
        {
            group.RecordDateTimeStamp = DateTime.Now;
            var storeContext = new StoreContext();
            if (ModelState.IsValid)
            {
                storeContext.Add(group);
                await storeContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }


       

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var storeContext = new StoreContext();
            if (id == null)
            {
                return NotFound();
            }

            var product =  storeContext.Groups.FirstOrDefault(m => m.GroupId == id);
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
            var product = await storeContext.Groups.FindAsync(id);
            storeContext.Groups.Remove(product);
            await storeContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
