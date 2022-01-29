using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.DAL.Entities.Base;
using Store.DAL.Enums;

namespace Store.DAL.Entities.Phone;

public partial class Phone : ItemBase
{   
    public int Memory { get; set; }
    
    [StringLength(20)]
    public string Color { get; set; } = "No info";
    
    //[StringLength(6)]
    public string ColorHex { get; set; } = "ffffff";

    public PhoneSpecifications Specifications { get; set; }
}