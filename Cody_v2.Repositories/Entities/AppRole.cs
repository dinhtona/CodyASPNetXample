using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Repositories.Entities
{
    public class AppRole: IdentityRole
    {
        [NotMapped]
        public string[] Claims { get; set; }
    }
}
