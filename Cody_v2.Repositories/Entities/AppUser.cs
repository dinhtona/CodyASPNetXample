using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cody_v2.Repositories.Entities
{
    public class AppUser: IdentityUser
    {
        [DataType("nvarchar")]
        [MaxLength(450)]
        public string? HomeAddress { get; set; }

        // [Required]       
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

    }
}
