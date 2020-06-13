using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApp.Data.Models;

namespace StoreApp.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger _logger;
        private StoreContext db;
        public GroupController(StoreContext context, ILogger<GroupController> logger)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {           
            var category = db.Groups;
            ViewBag.sessionUserName = HttpContext.Session.GetString("username");
            _logger.LogInformation("Просмотрена страница групп пользователем <<{0}>>", HttpContext.Session.GetString("userLogin"));
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
            if (ModelState.IsValid)
            {
                Group usergroup = await db.Groups.FirstOrDefaultAsync(u => u.GroupName.ToLower() == group.GroupName.ToLower());
                if (usergroup == null)
                {
                    group.RecordDateTimeStamp = DateTime.Now;
                    db.Add(group);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Такая группа уже зарегистрирована в базе данных");
                    _logger.LogError("Такая группа {0} уже зарегистрирована в базе данных", group.GroupName);
                }
                    
            }
            return View(group);
        }


       

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Groups.FirstOrDefaultAsync(m => m.GroupId == id);
            if (product == null)
            {
                return NotFound();
            }

            return  View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
          
            var product = await db.Groups.FindAsync(id);
            db.Groups.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var group = await db.Groups.FindAsync(id);
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
           
            group.RecordDateTimeStamp = DateTime.Now;
            if (id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Group usergroup = await db.Groups.FirstOrDefaultAsync(u => u.GroupName.ToLower() == group.GroupName.ToLower());
                if (usergroup == null)
                {
                    try
                    {
                        db.Update(group);
                        await db.SaveChangesAsync();
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
                else ModelState.AddModelError("", "Такая группа уже зарегистрирована в базе данных");



                
            }
            return View(group);
        }

        private bool ProductExists(long id)
        {
          
            return db.Groups.Any(e => e.GroupId == id);
        }

    }
}
