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

        public async Task<IActionResult> Login(ModelUser user)
        {
            var response = UserController.LoginByEmailAndPassword(user.Email, user.Password);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        public async Task<IActionResult> UserRegister() => View();

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
    }
}
