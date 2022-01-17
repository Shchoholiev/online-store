using System.ComponentModel.DataAnnotations;
using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.Laptop;

public partial class Laptop : ItemBase
{
    [StringLength(50)]
    public string Make { get; set; } = "No info";
    
    [StringLength(50)]
    public string Model { get; set; } = "No info";
    
    [StringLength(50)]
    public string Processor { get; set; } = "No info";
    
    public byte RAM { get; set; }
    
    public ushort Memory { get; set; }
}