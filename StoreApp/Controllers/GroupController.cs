using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class GroupController : Controller
    {
        private IGroupRepository groupRepository;

        public GroupController(IGroupRepository repo)
        {
            groupRepository = repo;
        }

        public ViewResult List() => View(groupRepository.Groups);
    }
}
