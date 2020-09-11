using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EFSqlStore.Model
{
    [Table("Produkten")]
    public class Produkt
    {
        public int ProduktId { get; set; }

        public string ProduktIdentificatie { get; set; }

        public decimal Prijs { get; set; }
    }
}
