using AutoMapper;
using Controllers;
using Controllers.Administration;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripRate.Models;
namespace TripRate.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserController _userController;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public LoginController(IUserController userController, IMapper mapper, IEmailSender emailSender)
        {
            this._userController = userController;
            this._mapper = mapper;
            this._emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserRegister() => View();

        [HttpGet]
        public async Task<IActionResult> ForgotPassword() => View();

        [HttpPost]
        public async Task<IActionResult> Login(ModelUser user)
        {
            var response = await _userController.LoginByEmailAndPassword(user.Email, user.Password);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            TripRateAdministration.SetCurrentUserLogged(null);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUserRegister(ModelUser user)
        {
            var userCreate = _mapper.Map<User>(user);
            var response = await _userController.RegisterUser(userCreate);

            if (response.Success)
            {
                return View("Index");
            }
            return View("UserRegister");
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailToResetPassword(string email)
        {
            // email validation

            var emailAdress = new List<EmailAdress>() 
            {
                new EmailAdress(email, email)
            };

            var message = new EmailMessage(emailAdress, "Test email", "This is the email test content");

            await _emailSender.SendEmailAsync(message);
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UserSettings()
        {
            return RedirectToAction("Index", "UserSettings");
        }
    }
}
