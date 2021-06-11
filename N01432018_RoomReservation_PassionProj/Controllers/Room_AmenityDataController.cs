using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using N01432018_RoomReservation_PassionProj.Models;

namespace N01432018_RoomReservation_PassionProj.Controllers
{
    public class Room_AmenityDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Room_AmenityData/ListRoomAmenity
        [HttpGet]
        public IEnumerable<Room_AmenityDto> ListRoomAmenity()
        {
            List<Room_Amenity> Room_Amenities = db.Room_Amenity.ToList();
            List<Room_AmenityDto> Room_AmenityDto = new List<Room_AmenityDto>();

            Room_Amenities.ForEach(a => Room_AmenityDto.Add(new Room_AmenityDto()
            {
                AmenityID = a.AmenityID,
                AmenityName = a.AmenityName,
            }));
            return Room_AmenityDto;
        }
    

        // GET: api/Room_AmenityData/FindRoomAmenity/5
        [ResponseType(typeof(Room_Amenity))]
        [HttpGet]
        public IHttpActionResult FindRoomAmenity(int id)
        {
            Room_Amenity room_Amenity = db.Room_Amenity.Find(id);
            Room_AmenityDto room_AmenityDto = new Room_AmenityDto()
            {
                AmenityID = room_Amenity.AmenityID,
                AmenityName = room_Amenity.AmenityName,
            };
            if (room_Amenity == null)
            {
                return NotFound();
            }

            return Ok(room_Amenity);
        }

        // POST: api/Room_AmenityData/UpdateRoomAmenity/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRoomAmenity(int id, Room_Amenity room_Amenity)
        {
            Debug.WriteLine("I have reached the update room amenity method");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_Amenity.AmenityID)
            {
                return BadRequest();
            }

            db.Entry(room_Amenity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_AmenityExists(id))
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

        // POST: api/Room_AmenityData/AddRoomAmenity
        [ResponseType(typeof(Room_Amenity))]
        [HttpPost]
        public IHttpActionResult AddRoomAmenity(Room_Amenity room_Amenity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Room_Amenity.Add(room_Amenity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room_Amenity.AmenityID }, room_Amenity);
        }

        // DELETE: api/Room_AmenityData/DeleteRoomAmenity/5
        [ResponseType(typeof(Room_Amenity))]
        [HttpPost]
        public IHttpActionResult DeleteRoomAmenity(int id)
        {
            Room_Amenity room_Amenity = db.Room_Amenity.Find(id);
            if (room_Amenity == null)
            {
                return NotFound();
            }

            db.Room_Amenity.Remove(room_Amenity);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Room_AmenityExists(int id)
        {
            return db.Room_Amenity.Count(e => e.AmenityID == id) > 0;
        }
    }
}