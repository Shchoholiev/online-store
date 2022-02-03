using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.DAL.Entities.Base;
using Store.DAL.Enums;

namespace Store.DAL.Entities.Phone;

public partial class Phone : ItemBase
{   
    public int Memory { get; set; }

    public PhoneSpecifications Specifications { get; set; }
}