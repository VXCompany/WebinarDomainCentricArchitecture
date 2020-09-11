namespace Domain.Model.Produkten
{
    public class Produkt
    {
        public Produkt(string identificatie, decimal prijs)
        {
            Identificatie = identificatie;
            Prijs = prijs;
        }

        public decimal Prijs { get; }

        public string Identificatie { get; }
    }
}
