namespace Infrastructure.EFSqlStore.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public Klant Klant { get; set; }

        public Produkt Produkt { get; set; }

        public int Aantal { get; set; }

        public decimal TotaalPrijs { get; set; }
    }
}
