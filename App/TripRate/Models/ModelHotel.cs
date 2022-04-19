using Models.Enums;
using System.ComponentModel;

namespace TripRate.Models
{
    public class ModelHotel
    {
        public int Id { get; set; }

        [DisplayName("Name of hotel")]
        public string HotelName { get; set; }
        public byte[] Image { get; set; }

        [DisplayName("Reservation Price p/day")]
        public decimal ReservationPrice { get; set; }
        public string Description { get; set; }

        [DisplayName("Type of hotel")]
        public HotelType HotelType { get; set; }
        public string Localization { get; set; }
    }
}
