namespace Domain.Model.Producten
{
    public class Product
    {
        public Product(string identificatie, decimal prijs)
        {
            Identificatie = identificatie;
            Prijs = prijs;
        }

        public decimal Prijs { get; }

        public string Identificatie { get; }
    }
}
