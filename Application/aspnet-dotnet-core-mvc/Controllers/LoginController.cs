using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using aspnet_dotnet_core_mvc.Models;
using aspnet_dotnet_core_mvc.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_dotnet_core_mvc.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService  loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginSubmit(LoginModel login)
        {            
            if(CheckUserCredentials(login).Result)
                return RedirectToAction("Index", "WeatherReport");
            TempData["LoginFailed"] = "Login details does not match.";
            return RedirectToAction("Index", "Home");
        }

        public async Task<bool> CheckUserCredentials(LoginModel login)
        {
            var hashedPassword =  _loginService.EncryptPlainTextToEncryptedText(login.Password);
            return await _loginService.CheckUserCredentials(login.LoginName, hashedPassword);
        }
    }
}