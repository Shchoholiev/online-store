using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.Phone;

public partial class Phone : ItemBase
{   
    public int Memory { get; set; }

    public PhoneSpecifications Specifications { get; set; }
}