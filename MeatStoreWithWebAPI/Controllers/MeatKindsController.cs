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
    public class MeatKindsController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        // GET: api/MeatKinds
        public IQueryable<MeatKind> GetMeatKinds()
        {
            return db.MeatKinds;
        }

        // GET: api/MeatKinds/5
        [ResponseType(typeof(MeatKind))]
        public async Task<IHttpActionResult> GetMeatKind(int id)
        {
            MeatKind meatKind = await db.MeatKinds.FindAsync(id);
            if (meatKind == null)
            {
                return NotFound();
            }

            return Ok(meatKind);
        }

        // PUT: api/MeatKinds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeatKind(int id, MeatKind meatKind)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meatKind.Id)
            {
                return BadRequest();
            }

            db.Entry(meatKind).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeatKindExists(id))
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

        // POST: api/MeatKinds
        [ResponseType(typeof(MeatKind))]
        public async Task<IHttpActionResult> PostMeatKind(MeatKind meatKind)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MeatKinds.Add(meatKind);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = meatKind.Id }, meatKind);
        }

        // DELETE: api/MeatKinds/5
        [ResponseType(typeof(MeatKind))]
        public async Task<IHttpActionResult> DeleteMeatKind(int id)
        {
            MeatKind meatKind = await db.MeatKinds.FindAsync(id);
            if (meatKind == null)
            {
                return NotFound();
            }

            db.MeatKinds.Remove(meatKind);
            await db.SaveChangesAsync();

            return Ok(meatKind);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeatKindExists(int id)
        {
            return db.MeatKinds.Count(e => e.Id == id) > 0;
        }
    }
}