namespace Store.ViewModels
{
    public class CartItemViewModel : EntityBaseViewModel
    {
        public ItemBaseViewModel Item { get; set; }

        public int Amount { get; set; }

        public int GetTotalPrice()
        {
            return this.Item.Price * this.Amount;
        }
    }
}
