namespace SnackBar.BadDesign
{
    public class Customer
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty; // usado em validações ad-hoc
        public string Type { get; set; } = String.Empty; // "Regular", "VIP", "Student"
    }

    // LSP violado: base impõe preparo quente pra todo item
    public class MenuItem
    {
        public string Name { get; set; } = String.Empty;
        public decimal BasePrice { get; set; }

        public virtual void PrepareHot()
        {
            Console.WriteLine($"Assando {Name}...");
        }
    }

    public class Burger : MenuItem
    {
        public override void PrepareHot() => Console.WriteLine($"Grelhando {Name}...");
    }

    // Sorvete não deveria “esquentar” — quebra LSP
    public class IceCream : MenuItem
    {
        public override void PrepareHot()
        {
            throw new NotSupportedException("Sorvete não é preparado quente.");
        }
    }
}
