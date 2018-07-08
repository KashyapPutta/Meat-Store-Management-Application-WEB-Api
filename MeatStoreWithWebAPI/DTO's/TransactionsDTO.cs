using MeatStoreWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatStoreWithWebAPI.DTO_s
{
    public class TransactionsDTO
    {
        public int TransactionId { get; set; }
        [Display(Name = "Quantity ")]
        public decimal QuantityPurchased { get; set; }

        [Display(Name = "Meat Type Id")]
        public int MeatKindId { get; set; }
        public MeatKind MeatKinds { get; set; }
        [Display(Name = "Purchase quantity bone")]
        public decimal BoneMeatQuantity { get; set; }
        [Display(Name = "Purchase quantity boneLess")]
        public decimal BonelessMeatQuantity { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        [Display(Name = "Date of transaction")]
        public DateTime TransactionDateTime { get; set; }
        [Display(Name = "From")]
        public DateTime FromDate { get; set; }
        [Display(Name = "To")]
        public DateTime ToDate { get; set; }
        public List<Transactions> TransactionsList { get; set; }
        public List<MeatKind> MeatKindsList { get; set; }
        public decimal TransactionTotal { get; set; }
    }
}