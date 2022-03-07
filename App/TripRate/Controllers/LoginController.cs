using AutoMapper;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using TripRate.Models;
namespace TripRate.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserController UserController;
        private readonly IMapper Mapper;

        public LoginController(IUserController userController, IMapper mapper)
        {
            this.UserController = userController;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserRegister() => View();

        [HttpGet]
        public async Task<IActionResult> ForgotPassword() => View();

        [HttpPost]
        public async Task<IActionResult> Login(ModelUser user)
        {
            var response = UserController.LoginByEmailAndPassword(user.Email, user.Password);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUserRegister(ModelUser user)
        {
            var userCreate = Mapper.Map<User>(user);
            var response = UserController.RegisterUser(userCreate);

            if (response.Success)
            {
                return View("Index");
            }
            return View("UserRegister");
        }

        //[HttpPost]
        //public async Task<IActionResult> SendEmailToResetPassword(string email)
        //{
        //    //var response = UserController.ResetPassword(email);
        //    return View();
        //}
    }
}
