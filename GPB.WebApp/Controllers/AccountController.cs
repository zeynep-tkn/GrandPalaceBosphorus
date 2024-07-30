using GPB.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using GPB.Domain.Entity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GPB.WebApp.Controllers

{

    public class AccountController : Controller

    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailSender _emailSender;




        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)

        {

            _userManager = userManager;

            _signInManager = signInManager;

            _emailSender = emailSender;

        }




        [HttpGet]

        public IActionResult LoginRegister()

        {

            return View();

        }




        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)

        {

            if (!ModelState.IsValid)

            {

                return View("LoginRegister", new LoginRegisterViewModel { Login = model });

            }




            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)

            {

                return RedirectToAction("Index", "Home");

            }

            else

            {

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");

                return View("LoginRegister", new LoginRegisterViewModel { Login = model });

            }

        }




        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)

        {

            if (!ModelState.IsValid)

            {

                return View("LoginRegister", model: new LoginRegisterViewModel { Register = model });

            }




            var user = new ApplicationUser

            {

                UserName = model.UserName,

                Email = model.Email,

                TcNumber = model.TcNumber

            };

            var result = await _userManager.CreateAsync(user, model.Password);




            if (result.Succeeded)

            {

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Doğrulayın",

                    $"Lütfen hesabınızı doğrulamak için <a href='{callbackUrl}'>buraya tıklayın</a>.");




                TempData["SuccessMessage"] = "Kayıt olma işlemi başarıyla tamamlandı. Lütfen e-posta adresinizi doğrulayın.";

                return RedirectToAction("LoginRegister", "Account");

            }

            else

            {

                foreach (var error in result.Errors)

                {

                    ModelState.AddModelError(string.Empty, error.Description);

                }

                return View("LoginRegister", model: new LoginRegisterViewModel { Register = model });

            }

        }




        [HttpGet]

        public async Task<IActionResult> ConfirmEmail(string userId, string code)

        {

            if (userId == null || code == null)

            {

                return RedirectToAction("Index", "Home");

            }




            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)

            {

                return NotFound($"Kullanıcı yüklenemedi. ID: '{userId}'.");

            }




            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)

            {

                return View("ConfirmEmail");

            }




            return View("Error");

        }

    }

}