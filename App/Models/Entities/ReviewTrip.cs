using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Models.Entities
{
    [Index(nameof(Localization), IsUnique = true)]
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

        public override Response Validate()
        {
            return base.Validate();
        }

        public override Response Save()
        {
            this.Validate();

            using (var context = new TripRateContext())
            {
                context.ReviewTrips.Add(this);
                var response = base.Save(context);
                if (response.Success)
                {
                    this.Saved();
                }
                return response;
            }
        }

        public override Response Saved()
        {
            return base.Saved();
        }

        public static ReviewTrip GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return context.ReviewTrips.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
