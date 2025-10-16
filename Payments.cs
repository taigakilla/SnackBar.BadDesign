namespace SnackBar.BadDesign
{
    // ISP violado: interface gorda (métodos que alguns pagamentos não usam)
    public interface IPaymentOperations
    {
        void Pay(decimal amount);
        void Refund(decimal amount);
        void SplitPayment(List<decimal> parts);
        void PrintReceipt(string text);
        void ApplyCoupon(string couponCode);
    }

    public class CashPayment : IPaymentOperations
    {
        public void Pay(decimal amount) => Console.WriteLine($"[CASH] Recebido {amount:0.00}");
        public void Refund(decimal amount) => throw new NotImplementedException();
        public void SplitPayment(List<decimal> parts) => throw new NotImplementedException();
        public void PrintReceipt(string text) => throw new NotImplementedException();
        public void ApplyCoupon(string couponCode) => Console.WriteLine($"Cupom '{couponCode}' anotado (sem efeito).");
    }

    public class CardPayment : IPaymentOperations
    {
        public void Pay(decimal amount) => Console.WriteLine($"[CARD] Cobrado {amount:0.00}");
        public void Refund(decimal amount) => Console.WriteLine($"[CARD] Estornado {amount:0.00}");
        public void SplitPayment(List<decimal> parts) { /* no-op só pra compilar */ }
        public void PrintReceipt(string text) => Console.WriteLine($"[CARD] Recibo: {text}");
        public void ApplyCoupon(string couponCode) => Console.WriteLine($"[CARD] Aplicando cupom '{couponCode}' sem validação…");
    }
}
