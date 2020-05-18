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
    }
}
