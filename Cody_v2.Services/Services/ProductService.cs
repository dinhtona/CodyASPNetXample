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
    public class ProductService: GenericService<Product>, IProductService
    {
        public ProductService(IGenericRepository<Product> repository) :base(repository)
        {

        }

        public async Task<List<Product>> GetAllCurrent()
        {
            return( await repository.GetByCondition(c=>c.IsDeleted!=true)).ToList();
        }
    }
}
