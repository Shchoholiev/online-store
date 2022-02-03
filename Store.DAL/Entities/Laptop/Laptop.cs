using System.ComponentModel.DataAnnotations;
using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.Laptop;

public partial class Laptop : ItemBase
{   
    [StringLength(50)]
    public string Processor { get; set; } = "No info";
    
    public int RAM { get; set; }
    
    public int Memory { get; set; }
}