using Cody_v2.Repositories.Entities;
using Cody_v2.Repositories.Interfaces;
using Cody_v2.Services.Generics;
using Cody_v2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Services.Services
{
    public class AppUserService : GenericService<AppUser>, IAppUserService
    {
        public AppUserService(IGenericRepository<AppUser> repository) : base(repository)
        {

        }
    }
}
