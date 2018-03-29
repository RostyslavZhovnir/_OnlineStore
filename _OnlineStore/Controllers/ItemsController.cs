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
using _OnlineStore.Models;

namespace _OnlineStore.Controllers
{
    public class ItemsController : ApiController
    {
        private myMagazEntities db = new myMagazEntities();

        // GET: api/Items
        public IQueryable<Items> GetItems()
        {
            return db.Items;
        }

        public IQueryable<Items> getlaptopsforeducation()
        {
            return db.Items.Where(x=>x.Category == "laptopsforeducation");
        }
        public IQueryable<Items> getlaptopsforbussines()
        {
            return db.Items.Where(x => x.Category == "laptopsforbussines");
        }
        public IQueryable<Items> getlaptopsapple()
        {
            return db.Items.Where(x => x.Category == "laptopsapple");
        }
        public IQueryable<Items> getipad()
        {
            return db.Items.Where(x => x.Category == "ipad");
        }
        public IQueryable<Items> getandroidtablets()
        {
            return db.Items.Where(x => x.Category == "androidtablets");
        }
        public IQueryable<Items> getcomputersapple()
        {
            return db.Items.Where(x => x.Category == "computersapple");
        }

        public IQueryable<Items> getdslrcameras()
        {
            return db.Items.Where(x => x.Category == "dslrcameras");
        }
        public IQueryable<Items> getdrones()
        {
            return db.Items.Where(x => x.Category == "drones");
        }


        // GET: api/Items/5
        [ResponseType(typeof(Items))]
        public IHttpActionResult GetItems(int id)
        {
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItems(int id, Items items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != items.id)
            {
                return BadRequest();
            }

            db.Entry(items).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
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

        // POST: api/Items
        [ResponseType(typeof(Items))]
        public IHttpActionResult PostItems(Items items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(items);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = items.id }, items);
        }

        // DELETE: api/Items/5
        [ResponseType(typeof(Items))]
        public IHttpActionResult DeleteItems(int id)
        {
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return NotFound();
            }

            db.Items.Remove(items);
            db.SaveChanges();

            return Ok(items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemsExists(int id)
        {
            return db.Items.Count(e => e.id == id) > 0;
        }
    }
}