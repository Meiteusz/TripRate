using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class HotelReview
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [StringLength(250)]
        public string ReviewText { get; set; }

        public int LikeCount { get; set; }
        #endregion
    }
}
