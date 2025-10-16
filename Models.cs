namespace SnackBar.BadDesign
{
    public class Customer
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty; // usado em valida��es ad-hoc
        public string Type { get; set; } = String.Empty; // "Regular", "VIP", "Student"
    }

    // LSP violado: base imp�e preparo quente pra todo item
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

    // Sorvete n�o deveria �esquentar� � quebra LSP
    public class IceCream : MenuItem
    {
        public override void PrepareHot()
        {
            throw new NotSupportedException("Sorvete n�o � preparado quente.");
        }
    }
}
