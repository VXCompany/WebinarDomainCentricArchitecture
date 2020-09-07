namespace BusinessLayer
{
    public class Order
    {
        public string KlantIdentificatie { get; set; }

        public string ProduktIdentificatie { get; set; }

        public int Aantal { get; set; }

        public decimal TotaalPrijs { get; set; }
    }
}
