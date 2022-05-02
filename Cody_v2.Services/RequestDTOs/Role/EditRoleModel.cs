using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Cody_v2.Services.RequestDTOs.Role
{
  public class EditRoleModel
    {
        [Display(Name = "Tên của role")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
        public string Name { get; set; }
        public List<IdentityRoleClaim<string>> Claims { get; set; }

        public IdentityRole role { get; set; }




    }
}
