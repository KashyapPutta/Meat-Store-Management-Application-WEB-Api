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

namespace MeatStoreWithWebAPI.Controllers
{
    public class MeatRatesController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        // GET: api/MeatRates
        public IQueryable<MeatRates> GetMeatRates()
        {
            return db.MeatRates;
        }

        // GET: api/MeatRates/5
        [ResponseType(typeof(MeatRates))]
        public async Task<IHttpActionResult> GetMeatRates(int id)
        {
            MeatRates meatRates = await db.MeatRates.FindAsync(id);
            if (meatRates == null)
            {
                return NotFound();
            }

            return Ok(meatRates);
        }

        // PUT: api/MeatRates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeatRates(int id, MeatRates meatRates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meatRates.Id)
            {
                return BadRequest();
            }

            db.Entry(meatRates).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeatRatesExists(id))
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

        // POST: api/MeatRates
        [ResponseType(typeof(MeatRates))]
        public async Task<IHttpActionResult> PostMeatRates(MeatRates meatRates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MeatRates.Add(meatRates);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = meatRates.Id }, meatRates);
        }

        // DELETE: api/MeatRates/5
        [ResponseType(typeof(MeatRates))]
        public async Task<IHttpActionResult> DeleteMeatRates(int id)
        {
            MeatRates meatRates = await db.MeatRates.FindAsync(id);
            if (meatRates == null)
            {
                return NotFound();
            }

            db.MeatRates.Remove(meatRates);
            await db.SaveChangesAsync();

            return Ok(meatRates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeatRatesExists(int id)
        {
            return db.MeatRates.Count(e => e.Id == id) > 0;
        }
    }
}