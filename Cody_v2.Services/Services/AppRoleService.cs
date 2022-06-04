using Cody_v2.Repositories.Entities;
using Cody_v2.Repositories.Interfaces;
using Cody_v2.Services.Generics;
using Cody_v2.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Services.Services
{
    public class AppRoleService : GenericService<AppRole>, IAppRoleService
    {
        public AppRoleService(IGenericRepository<AppRole> repository) : base(repository)
        {

        }
    }
}
