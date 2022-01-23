using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}