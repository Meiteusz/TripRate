using Microsoft.EntityFrameworkCore;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Hotel : EntityBase<Hotel>
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

        public static User CreateInstance()
        {
            return new User();
        }

        public async override Task<Response> Validate()
        {
            return await base.Validate();
        }

        public async override Task<Response> SaveAsync()
        {
            await this.Validate();

            using (var context = new TripRateContext())
            {
                context.Hotels.Add(this);
                var response = await base.SaveAsync(context);
                if (response.Success)
                {
                    await this.Saved();
                }
                return response;
            }
        }

        public async override Task<Response> Saved()
        {
            return await base.Saved();
        }

        public async static Task<Hotel> GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return await context.Hotels.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
