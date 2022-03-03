using Microsoft.EntityFrameworkCore;
using Models.DTO_s.Responses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : EntityBase<User>
    {
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
                var response = new Response(context);
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
    }
}
