﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using StoreApp.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using StoreApp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext db;
        private readonly ILogger _logger;
        public AccountController(StoreContext context, ILogger<AccountController> logger)
        {
            db = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => (u.Email == model.Email || u.UserLogin == model.Email) && u.UserPassword == model.Password);
                if (user != null)
                {

                    await Authenticate(model.Email); // аутентификация
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetString("userLogin", user.UserLogin);
                    _logger.LogInformation("Пользователь c логином {0} авторизовался успешно", user.UserLogin);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.UserLogin == model.UserLogin);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User 
                    { 
                        Email = model.Email, 
                        UserPassword = model.Password, 
                        UserLogin = model.UserLogin, 
                        UserName = model.UserName, 
                        RecordDateTimeStamp = DateTime.Now 
                    });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация
                    HttpContext.Session.SetString("username", model.UserName);
                    HttpContext.Session.SetString("userLogin", user.UserLogin);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Пользователь с такими данными уже зарегистрирован в базе данных");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("Пользователь {0} вышел", HttpContext.Session.GetString("userLogin"));
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("userLogin", "");
            return RedirectToAction("Login", "Account");
        }
    }
}

