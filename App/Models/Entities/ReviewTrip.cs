using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class ReviewTrip : EntityBase<ReviewTrip>
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Localization { get; set; }

        public int FavCounts { get; set; }

        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion

        public static ReviewTrip CreateInstance()
        {
            return new ReviewTrip();
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
                await context.ReviewTrips.AddAsync(this);
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

        public async static Task<ReviewTrip> GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return await context.ReviewTrips.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
