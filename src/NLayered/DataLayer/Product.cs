using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("Producten")]
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductIdentificatie { get; set; }

        public decimal Prijs { get; set; }
    }
}
