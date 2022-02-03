using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.ItemProperties
{
    public class Color : EntityBase
    {
        public string Name { get; set; }

        public string Hex { get; set; }
    }
}
