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
using GunzAPI.Models;

namespace GunzAPI.Controllers
{
    public class GunUsersController : ApiController
    {
        private GunzEntities db = new GunzEntities();

        // GET: api/GunUsers
        public IQueryable<GunUser> GetGunUsers()
        {
            return db.GunUsers;
        }

        // GET: api/GunUsers/5
        [ResponseType(typeof(GunUser))]
        public IHttpActionResult GetGunUser(int id)
        {
            GunUser gunUser = db.GunUsers.Find(id);
            if (gunUser == null)
            {
                return NotFound();
            }

            return Ok(gunUser);
        }

        // PUT: api/GunUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGunUser(int id, GunUser gunUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gunUser.GunUserID)
            {
                return BadRequest();
            }

            db.Entry(gunUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GunUserExists(id))
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

        // POST: api/GunUsers
        [ResponseType(typeof(GunUser))]
        public IHttpActionResult PostGunUser(GunUser gunUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GunUsers.Add(gunUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gunUser.GunUserID }, gunUser);
        }

        // DELETE: api/GunUsers/5
        [ResponseType(typeof(GunUser))]
        public IHttpActionResult DeleteGunUser(int id)
        {
            GunUser gunUser = db.GunUsers.Find(id);
            if (gunUser == null)
            {
                return NotFound();
            }

            db.GunUsers.Remove(gunUser);
            db.SaveChanges();

            return Ok(gunUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GunUserExists(int id)
        {
            return db.GunUsers.Count(e => e.GunUserID == id) > 0;
        }
    }
}