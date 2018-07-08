using MeatStoreWithWebAPI.DTO_s;
using MeatStoreWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeatStoreWithWebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        //public IHttpActionResult GetNewOrder()
        //{

        //    var dtomodel = new OrderDTO();

        //    dtomodel.MeatKindsList = db.MeatKinds.ToList();
        //    //dtomodel.InventoryList = _meatcontext.Inventories.ToList();
        //    dtomodel.MeatRatesList = db.MeatRates.ToList();


        //    return Ok(dtomodel);
        //}

        [HttpPost]
        public IHttpActionResult TotalCost([FromUri] OrderDTO dtomodel)

        {

            //if (!ModelState.IsValid)
            //{
            //    var suppliesViewModelObject = new MeatViewModel()
            //    {
            //        InventoryList = _meatcontext.Inventories.ToList(),
            //        MeatKindList = _meatcontext.MeatKind.ToList(),
            //        TotalCost = meatviewmodel.Meats.SubTotal,
            //        MeatRatesList = _meatcontext.MeatRates.ToList(),
            //    };
            //    return View("index", suppliesViewModelObject);
            //}

            //var quantityinDB = db.Inventories.Single(c => c.MeatKindId == meatviewmodel.MeatKinds.Id);

            //if (quantityinDB.QuantityInStock < meatviewmodel.Meats.Quantity)
            //{
            //    var viewmodelobjectofmeat = new MeatViewModel()
            //    {
            //        InventoryList = _meatcontext.Inventories.ToList(),
            //        MeatKindList = _meatcontext.MeatKind.ToList(),
            //        TotalCost = meatviewmodel.Meats.SubTotal,
            //        MeatRatesList = _meatcontext.MeatRates.ToList(),
            //    };
            //    ModelState.AddModelError("Meats.Quantity", "Not enough Inventory!!! Only" + quantityinDB.QuantityInStock + "lbs are available");

            //    return View("index", viewmodelobjectofmeat);
            //}




            var ratesInDB = db.MeatRates.Single(c => c.MeatKindId == dtomodel.MeatKinds.Id);
            if (dtomodel.IsBoneless == true)
                dtomodel.SubTotal = dtomodel.Calculate(dtomodel.Quantity, ratesInDB.CostPerLbBoneless);
            else
                dtomodel.SubTotal = dtomodel.Calculate(dtomodel.Quantity, ratesInDB.CostPerLb);

            var x = new Transactions();
            x.QuantityPurchased = dtomodel.Quantity;
            x.MeatKindId = dtomodel.MeatKinds.Id;
            x.TotalPurchaseAmount = (int)dtomodel.SubTotal;
            x.TransactionDateTime = DateTime.Now;


            if (dtomodel.IsBoneless == true)
            {
                x.BonelessMeatQuantity = dtomodel.Quantity;
                x.BoneMeatQuantity = 0;
            }

            if (dtomodel.IsBoneless == false)
            {
                x.BoneMeatQuantity = dtomodel.Quantity;
                x.BonelessMeatQuantity = 0;
            }

            db.Transactions.Add(x);
            db.SaveChanges();

            //var meatkindlist = db.MeatKinds.ToList();

            //foreach (var eachname in meatkindlist)
            //{

            //    if (dtomodel.MeatKinds.Id == eachname.Id)
            //    {
            //        var db = db.Inventories.Single(c => c.MeatKindId == eachname.Id);
            //        db.QuantityInStock = db.QuantityInStock - meatviewmodel.Meats.Quantity;
            //    }


            //}
            //_meatcontext.SaveChanges();

            var dtonewmodel = new OrderDTO()
            {
                //InventoryList = _meatcontext.Inventories.ToList(),
                //MeatKindsList = db.MeatKinds.ToList(),
                SubTotal = dtomodel.SubTotal,
                //MeatRatesList = db.MeatRates.ToList(),
            };

            return Ok(dtonewmodel.SubTotal);
        }



    }
}
