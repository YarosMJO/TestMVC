using Microsoft.AspNetCore.Mvc;
using TestMVC.BL.Services;
using TestMVC.Shared.DTOs;

namespace TestMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly  LoginService loginService;
        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginDto loginDto)
        {
            if (loginService.CheckValidation(loginDto)) return RedirectToAction("Index","User");
            return BadRequest();
        }
    }
}