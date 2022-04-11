using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Hotel
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string HotelName { get; set; }

        public byte[] Image { get; set; } 

        [Required]
        [Range(50, double.PositiveInfinity)]
        public decimal ReservationPrice { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public HotelType HotelType { get; set; }

        [Required]
        [StringLength(100)]
        public string Localization { get; set; }
        #endregion
    }
}
