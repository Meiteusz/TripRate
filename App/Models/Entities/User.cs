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

        public async override Task<Response> Validate()
        {
            return await base.Validate();
        }

        public async override Task<Response> SaveAsync()
        {
            await this.Validate();

            using (var context = new TripRateContext())
            {
                context.Users.Add(this);
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

        public static async Task<User> GetFirstOrDefault(string email, string password)
        {
            using (var context = new TripRateContext())
            {
                return await context.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            }
        }

        public async static Task<User> GetFirstOrDefault(int id)
        {
            using (var context = new TripRateContext())
            {
                return await context.Users.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
