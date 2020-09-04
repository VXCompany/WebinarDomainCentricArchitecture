namespace BusinessLayer
{
    public class Order
    {
        public int Klantnummer { get; set; }

        public string ProduktIdentificatie { get; set; }

        public int Aantal { get; set; }

        public decimal TotaalPrijs { get; set; }
    }
}
