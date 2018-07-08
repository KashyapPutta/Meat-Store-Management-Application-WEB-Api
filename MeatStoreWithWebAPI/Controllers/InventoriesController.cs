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
    public class InventoriesController : ApiController
    {
        private MeatStoreWithWebAPIContext db = new MeatStoreWithWebAPIContext();

        // GET: api/Inventories
        public IEnumerable<Inventory> GetInventories()
        {
            return db.Inventories.ToList() ;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

 
        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> DeleteInventory(int id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            db.Inventories.Remove(inventory);
            await db.SaveChangesAsync();

            return Ok(inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryExists(int id)
        {
            return db.Inventories.Count(e => e.Id == id) > 0;
        }
    }
}