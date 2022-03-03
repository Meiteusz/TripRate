using System.ComponentModel;

namespace TripRate.Models
{
    public class ModelUser
    {
        [DisplayName("First Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
