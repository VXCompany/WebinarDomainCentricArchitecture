﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EFSqlStore.Model
{
    [Table("Producten")]
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductIdentificatie { get; set; }

        public decimal Prijs { get; set; }
    }
}
