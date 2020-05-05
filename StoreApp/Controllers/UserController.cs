using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace StoreApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
       
        public UserController(IUserRepository repo)
        {
            userRepository = repo;
        }

        public ViewResult List() => View(userRepository.Users);

      
    }
}
