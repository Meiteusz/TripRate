using AutoMapper;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserController _userController;

        public UserSettingsController(IMapper mapper, IUserController userController)
        {
            this._mapper = mapper;
            this._userController = userController;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUpdate(ModelUser modelUser)
        {
            var user = _mapper.Map<User>(modelUser);
            var response = await _userController.UpdateUserSettings(user);

            if (response.Success)
            {
                return View("Index");
            }
            return RedirectToAction("Error", "ErrorBag");
        }
    }
}
