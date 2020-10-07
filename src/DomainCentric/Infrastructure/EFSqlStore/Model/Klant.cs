using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EFSqlStore.Model
{
    [Table("Klanten")]
    public class Klant
    {
        public int KlantId { get; set; }

        public string KlantIdentificatie { get; set; }
    }
}
