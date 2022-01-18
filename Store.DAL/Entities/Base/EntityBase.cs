using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities.Base;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}