namespace Store.ViewModels
{
    public class OrderViewModel : EntityBaseViewModel
    {
        public OrderViewModel()
        {
        }

        public OrderViewModel(IEnumerable<CartItemViewModel> items)
        {
            Items = items;
            foreach (var item in items)
            {
                TotalPrice += item.GetTotalPrice();
            }
        }

        public IEnumerable<CartItemViewModel> Items { get; set; }

        public int TotalPrice { get; set; }

        public int Delivery { get; set; }

        public string? DeliveryAddress { get; set; }

        public int Payment { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsPaid { get; set; }

        public string? Details { get; set; }
    }
}
