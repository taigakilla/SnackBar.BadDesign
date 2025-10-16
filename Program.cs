namespace SnackBar.BadDesign
{
    class Program
    {
        static void Main()
        {
            var service = new OrderService();

            var pedido1 = new Order
            {
                Customer = new Customer { Name = "Ana", Email = "ana@example.com", Type = "VIP" },
                PaymentMethod = "Cash",
                Items = new List<MenuItem>
                {
                    new Burger { Name = "Burger", BasePrice = 20m },
                    new IceCream { Name = "Sorvete", BasePrice = 10m } // LSP vai estourar
                }
            };

            try { service.PlaceOrder(pedido1); }
            catch (Exception ex) { Console.WriteLine($"[ERRO esperado] {ex.Message}"); }

            var pedido2 = new Order
            {
                Customer = new Customer { Name = "Bruno", Email = "brunoexample.com", Type = "Student" },
                PaymentMethod = "Card",
                Items = new List<MenuItem> { new Burger { Name = "Burger Duplo", BasePrice = 30m } }
            };

            service.PlaceOrder(pedido2);
        }
    }
}
