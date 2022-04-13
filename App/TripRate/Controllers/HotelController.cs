using AutoMapper;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    public class HotelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHotelController _hotelController;

        public HotelController(IMapper mapper, IHotelController hotelController)
        {
            this._mapper = mapper;
            this._hotelController = hotelController;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HotelRegister()
        {
            return View();
        }

        public async Task<IActionResult> RegisterHotel(HotelModel hotelModel)
        {
            var hotel = _mapper.Map<Hotel>(hotelModel);
            var response = await _hotelController.RegisterHotel(hotel);

            if (response.Success)
                return View("Index");

            return RedirectToAction("Error", "ErrorBag");
        }
    }
}
