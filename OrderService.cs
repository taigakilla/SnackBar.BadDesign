namespace SnackBar.BadDesign
{
    // SRP + OCP + DIP + ISP violados de propósito
    public class OrderService
    {
        // DIP violado: instanciando concretos aqui dentro
        private readonly OrderRepository _repo = new OrderRepository();
        private readonly EmailSender _email = new EmailSender();

        public void PlaceOrder(Order order)
        {
            Console.WriteLine("== Processando pedido ==");

            // (1) Validação — SRP violado
            if (order.Customer == null || string.IsNullOrWhiteSpace(order.Customer.Email) || !order.Customer.Email.Contains("@"))
            {
                Console.WriteLine("Email inválido. Cancelando.");
                return;
            }
            if (order.Items.Count == 0)
            {
                Console.WriteLine("Pedido sem itens. Cancelando.");
                return;
            }

            // (2) Preparo — LSP vai quebrar no sorvete
            foreach (var i in order.Items) i.PrepareHot();

            // (3) Subtotal — SRP violado
            decimal subtotal = 0m;
            foreach (var i in order.Items) subtotal += i.BasePrice;

            // (4) Desconto com switch — OCP violado
            decimal discount = order.Customer.Type switch
            {
                "Regular" => subtotal * 0.05m,
                "VIP" => subtotal * 0.15m,
                "Student" => subtotal * 0.10m,
                _ => 0m
            }; //esse é um jeito de fazer switch em c# deixei aqui pra vc aprender mas funciona do msm jeito do outro

            order.Total = subtotal - discount;

            // (5) Pagamento — ISP violado (interface gorda) + SRP violado
            IPaymentOperations payment = order.PaymentMethod == "Cash"
                ? new CashPayment()
                : new CardPayment();

            payment.ApplyCoupon("LANCHAO10"); // não faz sentido pra cash
            payment.Pay(order.Total);
            payment.PrintReceipt($"Pedido #{order.Id} - Total {order.Total:0.00}");

            // (6) Persistência — DIP + SRP violados
            _repo.Save(order);

            // (7) Notificação — DIP + SRP violados
            _email.Send(order.Customer.Email, "Seu pedido saiu!", $"Total {order.Total:0.00}");

            Console.WriteLine("== Concluído ==");
        }
    }
}
