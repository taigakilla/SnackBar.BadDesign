namespace SnackBar.BadDesign
{
    // DIP violado: detalhes concretos que a aplicação conhece diretamente
    public class OrderRepository
    {
        public void Save(Order order) =>
            Console.WriteLine($"[DB] Pedido #{order.Id} salvo ({order.Items.Count} item(ns)).");
    }

    public class EmailSender
    {
        public void Send(string to, string subject, string body) =>
            Console.WriteLine($"[SMTP] Para: {to} | {subject}\n{body}");
    }
}
