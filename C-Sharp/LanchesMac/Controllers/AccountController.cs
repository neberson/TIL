﻿using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
           return View(loginViewModel);

        var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                if(string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginViewModel.ReturnUrl);
            }
        }
        ModelState.AddModelError("", "Falha ao realizar o login!!");
        return View(loginViewModel);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = loginViewModel.UserName };
            var result = await _userManager.CreateAsync(user, loginViewModel.Password);

            if (result.Succeeded) 
            {
                return RedirectToAction("Login", "Account");
            } else
            {
                this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
            }
        }
        return View(loginViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
