using System;

namespace Domain.Model.Klanten
{
    public class Klant
    {
        public Klant(string klantIdentificatie)
        {
            KlantIdentificatie = klantIdentificatie ?? throw new ArgumentNullException(nameof(klantIdentificatie));
        }

        public string KlantIdentificatie { get; }
    }
}
