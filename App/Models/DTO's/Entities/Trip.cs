using System.ComponentModel.DataAnnotations;

namespace Models.DTO_s.Entities
{
    public class Trip
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
    }
}
