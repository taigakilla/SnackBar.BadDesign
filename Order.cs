namespace SnackBar.BadDesign
{
    public class Order
    {
        private static int _seq = 1;
        public int Id { get; private set; } = _seq++;
        public Customer Customer { get; set; } = new();
        public List<MenuItem> Items { get; set; } = new();
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; } = String.Empty; // "Cash" ou "Card"
    }
}
