using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models.DTO_s.Entities
{
    [Index(nameof(Localization), IsUnique = true)]
    public class Trip : EntityBase<Trip>
    {
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

        public static Trip CreateInstance()
        {
            return new Trip();
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
                context.Trips.Add(this);
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

        public static Trip GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return context.Trips.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
