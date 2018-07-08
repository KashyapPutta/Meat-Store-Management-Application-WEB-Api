using MeatStoreWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatStoreWithWebAPI.DTO_s
{
    public class OrderDTO
    {
        [Required]
        public decimal Quantity { get; set; }

        [Display(Name = "Is Boneless ?")]
        public bool IsBoneless { get; set; }
        public decimal SubTotal { get; set; }

        public decimal Calculate(decimal Quantity, decimal CostPerLb)
        {

            return Quantity * CostPerLb;
        }

        public MeatRates MeatRates { get; set; }
        public MeatKind MeatKinds { get; set; }
        public List<MeatRates> MeatRatesList { get; set; }
        public List<MeatKind> MeatKindsList { get; set; }
    }
}