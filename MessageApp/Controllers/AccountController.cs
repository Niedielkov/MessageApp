using MessageApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _accountRepository.PasswordSignIn(username, password);

            if(result.Succeeded)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await _accountRepository.CreateUser(username, password);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Register", "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}
