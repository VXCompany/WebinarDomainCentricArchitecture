namespace BusinessLayer
{
    public class OrderService
    {
        public void PlaatsOrder(Order order)
        {
            var produkt = HaalProduktOp(order.ProduktIdentificatie);

            if (order.Aantal >= 10)
            {
                order.TotaalPrijs = (order.Aantal * produkt.Prijs) * 0.95m;
            }
            else
            {
                order.TotaalPrijs = order.Aantal * produkt.Prijs;
            }
        }

        private Produkt HaalProduktOp(string produktIdentificatie)
        {
            return new Produkt { Prijs = 25.0m, ProduktIdentificatie = produktIdentificatie };
        }
    }
}
