namespace BusinessLayer
{
    public class PrijsBerekenService
    {
        public decimal BerekenTotaalPrijs(decimal stukprijs, int aantal)
        {
            decimal totaalPrijs = 0;

            if (aantal >= 10)
            {
                totaalPrijs = (aantal * stukprijs) * 0.95m;
            }
            else
            {
                totaalPrijs = aantal * stukprijs;
            }

            return totaalPrijs;
        }
    }
}
