using AutoMapper;
using Controllers;
using Controllers.Administration;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using TripRate.Models;
namespace TripRate.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserController _userController;
        private readonly IMapper _mapper;

        public LoginController(IUserController userController, IMapper mapper)
        {
            this._userController = userController;
            this._mapper = mapper;
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
            var response = _userController.LoginByEmailAndPassword(user.Email, user.Password);
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
            var response = _userController.RegisterUser(userCreate);

            if (response.Success)
            {
                return View("Index");
            }
            return View("UserRegister");
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailToResetPassword(string email)
        {
            //var response = UserController.ResetPassword(email);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserSettings()
        {
            return RedirectToAction("Index", "UserSettings");
        }
    }
}
