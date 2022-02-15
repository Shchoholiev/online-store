using Store.ViewModels.ItemsProperties;

namespace Store.ViewModels.Phone
{
    public class PhoneEditViewModel : PhoneViewModel
    {
        //public new BrandViewModel Brand { get; set; }

        //public new ModelViewModel Model { get; set; }

        //public new ColorViewModel Color { get; set; }

        public int SpecsId { get; set; }

        public IEnumerable<BrandViewModel> Brands { get; set; }

        public IEnumerable<ModelViewModel> Models { get; set; }

        public IEnumerable<ColorViewModel> Colors { get; set; }        
    }
}
