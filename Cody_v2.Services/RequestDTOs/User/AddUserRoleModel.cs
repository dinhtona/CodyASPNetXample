using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Cody_v2.Services.RequestDTOs.User
{
    public class AddUserRoleModel
  {
    public Cody_v2.Repositories.Entities.AppUser user { get; set; }

    [DisplayName("Các role gán cho user")]
    public string[] RoleNames { get; set; }

    public List<IdentityRoleClaim<string>> claimsInRole { get; set; }
    public List<IdentityUserClaim<string>> claimsInUserClaim { get; set; }

  }
}