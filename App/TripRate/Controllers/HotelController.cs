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

        public async Task<IActionResult> Index(string localization)
        {
            ViewBag.HotelQueryResponse = await _hotelController.GetFullQuery();
            return View();
        }

        public async Task<IActionResult> HotelRegister(string localization)
        {
            return View();
        }

        public async Task<IActionResult> RegisterHotel(ModelHotel hotelModel)
        {
            var hotel = _mapper.Map<Hotel>(hotelModel);
            var response = await _hotelController.RegisterHotel(hotel);

            if (response.Success)
                return View("Index");

            return RedirectToAction("Error", "ErrorBag");
        }
    }
}
