using Microsoft.EntityFrameworkCore;
using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : EntityBase<User>
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public UserTypes UserType { get; set; }

        #endregion

        public static User CreateInstance()
        {
            return new User();
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
                context.Users.Add(this);
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

        public static async Task<User> GetFirstOrDefault(string email, string password)
        {
            using (var context = new TripRateContext())
            {
                return await context.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            }
        }

        public static User GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return context.Users.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
