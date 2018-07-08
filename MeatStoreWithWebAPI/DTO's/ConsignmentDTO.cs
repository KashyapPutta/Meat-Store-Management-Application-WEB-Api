using MeatStoreWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatStoreWithWebAPI.DTO_s
{
    public class ConsignmentDTO
    {


        [Key]
        public int ConsignmentId { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [Required]
        [Display(Name = "Meat Type")]
        public string MeatType { get; set; }
        public decimal Quantity { get; set; }
        public DateTime SuppliedDate { get; set; }
        [Required]
        [Display(Name = "Bill Amount")]
        public decimal BillAmount { get; set; }




        //    public List<Transactions> TransactionsList { get; set; }
        //    [Display(Name = "From")]
        //    [Required]
        //    public DateTime FromDate { get; set; }
        //    [Display(Name = "To")]
        //    [Required]
        //    public DateTime ToDate { get; set; }
        //    public Inventory Inventory { get; set; }
            public MeatKind MeatKinds { get; set; }
              public List<MeatKind> MeatKindList { get; set; }
            public List<Inventory> InventoryList { get; set; }
        //    public Consignment Consignment { get; set; }
            public List<Consignment> ConsignmentList { get; set; }
        //    public Vendor Vendors { get; set; }
            public List<Vendor> VendorList { get; set; }
        //    public bool SelectMeatType { get; set; }
    }
}