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
        public readonly IUserController UserController;
        public readonly IMapper Mapper;

        public LoginController(IUserController userController, IMapper mapper)
        {
            this.UserController = userController;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserRegister() => View();

        public async Task<IActionResult> ConfirmUserRegister(ModelUser user)
        {
            var userCreate = Mapper.Map<User>(user);
            var a = UserController.RegisterUser(userCreate);
            return View();
        }
    }
}
