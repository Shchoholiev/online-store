using Store.DAL.Entities.Base;
using Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities.EntitiesForEnums
{
    public class Brand
    {
        public BrandId BrandId { get; set; }
        public string Name { get; set; }
    }
}
