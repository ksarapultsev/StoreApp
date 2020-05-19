using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var storeContext = new StoreContext();
            if (id == null)
            {
                return NotFound();
            }

            var group = await storeContext.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GroupId,GroupName,Description")] Group group)
        {
            var _context = new StoreContext();
            group.RecordDateTimeStamp = DateTime.Now;
            if (id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(group.GroupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        private bool ProductExists(long id)
        {
            var _context = new StoreContext();
            return _context.Groups.Any(e => e.GroupId == id);
        }

    }
}
