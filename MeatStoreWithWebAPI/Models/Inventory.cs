using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatStoreWithWebAPI.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public int MeatKindId { get; set; }
        public virtual MeatKind MeatKind { get; set; }

        [Required]
        public decimal QuantityInStock { get; set; }
    }
}