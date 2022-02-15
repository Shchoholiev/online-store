using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.ItemProperties
{
    public class Image : EntityBase
    {
        public string Link { get; set; }

        public List<ItemBase> Items { get; set; }
    }
}
