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
using MVCinWebAPI.Models;

namespace MVCinWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        private NarocilaContext db = new NarocilaContext();

        // GET: api/Admin
        public IQueryable<Produkt> GetProdukts()
        {
            return db.Produkts;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(Produkt))]
        public IHttpActionResult GetProdukt(int id)
        {
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }

            return Ok(produkt);
        }

        // PUT: api/Admin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdukt(int id, Produkt produkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produkt.Id)
            {
                return BadRequest();
            }

            db.Entry(produkt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        // POST: api/Admin
        [ResponseType(typeof(Produkt))]
        public IHttpActionResult PostProdukt(Produkt produkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produkts.Add(produkt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produkt.Id }, produkt);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(Produkt))]
        public IHttpActionResult DeleteProdukt(int id)
        {
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }

            db.Produkts.Remove(produkt);
            db.SaveChanges();

            return Ok(produkt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProduktExists(int id)
        {
            return db.Produkts.Count(e => e.Id == id) > 0;
        }
    }
}