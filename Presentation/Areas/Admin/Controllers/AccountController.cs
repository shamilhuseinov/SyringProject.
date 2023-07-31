﻿using System;
using Business.ViewModels.User.Account;
using Microsoft.AspNetCore.Mvc;
using Business.ViewModels.Admin.Account;


using Business.Services.Admin.Abstract;


namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            var isSucceeded = await _accountService.Login(model);
            if (isSucceeded) return RedirectToAction(nameof(Index), "dashboard");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}

