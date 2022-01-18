using System.ComponentModel.DataAnnotations;
using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.Phone;

public partial class Phone : ItemBase
{
    [StringLength(50)]
    public string Make { get; set; } = "No info";
    
    [StringLength(50)]
    public string Model { get; set; } = "No info";
    
    public ushort Memory { get; set; }
    
    [StringLength(20)]
    public string Color { get; set; } = "No info";
    
    [StringLength(6)]
    public string ColorHex { get; set; } = "ffffff";
}