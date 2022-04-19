using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Repositories.Entities
{
    public class Product:BaseEntity
    {
        [MaxLength(256)]
        [DataType("nvarchar")]
        public string Name { get; set; }
    }
}
