using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MeatStoreWithWebAPI.Models;
using MeatStoreWithWebAPI.DTO_s;

namespace MeatStoreWithWebAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        // GET: api/Transactions
        //public IEnumerable<Transactions> GetTransactions()
        //{

        //    return db.Transactions.ToList();
        //}

        // GET: api/Transactions/5
        [ResponseType(typeof(Transactions))]
        public async Task<IHttpActionResult> GetTransactions(int id)
        {
            Transactions transactions = await db.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        //// PUT: api/Transactions/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutTransactions(int id, Transactions transactions)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != transactions.TransactionId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(transactions).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TransactionsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Transactions
        
        public IHttpActionResult GetFilterTransactions([FromUri] TransactionsDTO dtoModelTranscations)
        {
            //ModelState.Remove("MeatKinds.Id");
            //if (!ModelState.IsValid)
            //{
            //    var suppliesViewModelObject = new TransactionViewModel()
            //    {
            //        Fromdate = DateTime.Today.Date,
            //        Todate = DateTime.Today.Date,
            //        MeatKindList = _context.MeatKind.ToList(),
            //        TransactionTotal = transactionviewmodel.TransactionList.Sum(c => c.QuantityPurchased)

            //    };
            //    return View("TransactionHistory", suppliesViewModelObject);
            //}

            string converttostringFromDate = dtoModelTranscations.FromDate.ToString("M/dd/yyyy");
            string converttostringToDate = dtoModelTranscations.ToDate.ToString("M/dd/yyyy");
            bool checkIfFinished = true;
            var transactionslist = db.Transactions.ToList();
            List<Transactions> sorted = new List<Transactions>();

            while (checkIfFinished == true)
            {
                foreach (var eachtransaction in transactionslist)
                {
                    if (eachtransaction.TransactionDateTime.Date == dtoModelTranscations.FromDate.Date)
                    {
                        sorted.Add(eachtransaction);

                    }

                }

                if (dtoModelTranscations.FromDate.Date != dtoModelTranscations.ToDate.Date)
                    dtoModelTranscations.FromDate = dtoModelTranscations.FromDate.AddDays(1);
                else
                    checkIfFinished = false;
            }

            if (dtoModelTranscations.MeatKindId == 0)
            {
                var _meattypeslist = db.MeatKinds.ToList();
                var filteredjustdatetransactions = new TransactionsDTO()
                {
                    TransactionsList = sorted,
                    MeatKindsList = _meattypeslist,
                    TransactionTotal = sorted.Sum(c => c.QuantityPurchased),
                };
                return Ok(filteredjustdatetransactions);
            }

            List<Transactions> dab = new List<Transactions>();
            if (dtoModelTranscations.MeatKinds.Id != 0)
            {
                var Transactionslist = db.Transactions.ToList();
                var meattypeslist = db.MeatKinds.ToList();
                var filteredmeattypealsotransactions = new TransactionsDTO();

                filteredmeattypealsotransactions.TransactionsList = sorted.Where(c => c.MeatKindId == dtoModelTranscations.MeatKinds.Id).ToList();
                filteredmeattypealsotransactions.MeatKindsList = meattypeslist;
                filteredmeattypealsotransactions.TransactionTotal = sorted.Sum(c => c.QuantityPurchased);
                return Ok(filteredmeattypealsotransactions);
            }
            return Ok();
        }

        // DELETE: api/Transactions/5
        [ResponseType(typeof(Transactions))]
        public async Task<IHttpActionResult> DeleteTransactions(int id)
        {
            Transactions transactions = await db.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            db.Transactions.Remove(transactions);
            await db.SaveChangesAsync();

            return Ok(transactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionsExists(int id)
        {
            return db.Transactions.Count(e => e.TransactionId == id) > 0;
        }
    }
}