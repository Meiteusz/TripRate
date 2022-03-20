namespace TripRate.Models
{
    public class ModelTrip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public int FavCounts { get; set; }
    }
}
