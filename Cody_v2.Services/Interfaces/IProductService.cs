using Cody_v2.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Services.Interfaces
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetAllCurrent();
    }
}
