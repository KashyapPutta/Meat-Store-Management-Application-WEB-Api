using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MeatStoreWithWebAPI.Models;
using MeatStoreWithWebAPI.DTO_s;

namespace MeatStoreWithWebAPI.Controllers
{
    public class ConsignmentsController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        // GET: api/Consignments
        public IEnumerable<Consignment> GetConsignments()
        {
            return db.Consignments.ToList();
        }

        // GET: api/Consignments/5
        [ResponseType(typeof(Consignment))]
        public IHttpActionResult GetConsignment(int id)
        {
            Consignment consignment = db.Consignments.Find(id);
            if (consignment == null)
            {
                return NotFound();
            }

            return Ok(consignment);
        }

        // PUT: api/Consignments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsignment(int id, Consignment consignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consignment.ConsignmentId)
            {
                return BadRequest();
            }

            db.Entry(consignment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Consignments
        [HttpPost]
        public IHttpActionResult PostConsignment([FromUri] ConsignmentDTO consignmentDtoModel)
        {
            var meattypeslist = db.MeatKinds.ToList();
            var consignmentobject = new Consignment();
            var vendorslist = db.Vendors.ToList();

            consignmentobject.VendorId = consignmentDtoModel.VendorId;
            consignmentobject.MeatType = db.MeatKinds.Single(c => c.Id == consignmentDtoModel.MeatKinds.Id).MeatName;
            consignmentobject.Quantity = consignmentDtoModel.Quantity;
            consignmentobject.BillAmount = consignmentDtoModel.BillAmount;
            consignmentobject.SuppliedDate = DateTime.Now;

            db.Consignments.Add(consignmentobject);
            db.SaveChanges();

            //List<Inventory> inventorylist = new List<Inventory>();

            var df = db.Inventories.Single(c => c.MeatKindId == consignmentDtoModel.MeatKinds.Id);


            df.QuantityInStock = df.QuantityInStock + consignmentDtoModel.Quantity;


            
            var suppliesviewmodelobject = new ConsignmentDTO()
            {
                ConsignmentList = db.Consignments.ToList(),
                MeatKindList = db.MeatKinds.ToList(),
                VendorList = vendorslist,

            };
            return Ok(suppliesviewmodelobject);
        }


        // DELETE: api/Consignments/5
        [ResponseType(typeof(Consignment))]
        public IHttpActionResult DeleteConsignment(int id)
        {
            Consignment consignment = db.Consignments.Find(id);
            if (consignment == null)
            {
                return NotFound();
            }

            db.Consignments.Remove(consignment);
            db.SaveChanges();

            return Ok(consignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsignmentExists(int id)
        {
            return db.Consignments.Count(e => e.ConsignmentId == id) > 0;
        }
    }
}