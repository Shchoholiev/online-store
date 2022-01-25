namespace Store.ViewModels
{
    public class CartItemViewModel : EntityBaseViewModel
    {
        public ItemBase Item { get; set; }

        public int Amount { get; set; }

        //public int? User { get; set; } // ?
    }
}
