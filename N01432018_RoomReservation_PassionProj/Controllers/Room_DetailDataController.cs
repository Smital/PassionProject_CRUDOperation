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
    public class Room_DetailDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Room_DetailData/ListRoomDetails
        public IEnumerable<Room_DetailDto> ListRoomDetails()
        {
            List<Room_Detail> Room_Details = db.Room_Details.ToList();
            List<Room_DetailDto> Room_DetailDto = new List<Room_DetailDto>();

            Room_Details.ForEach(a => Room_DetailDto.Add(new Room_DetailDto()
            {
                RoomID = a.RoomID,
                RoomNumber = a.RoomNumber,
                RoomType = a.RoomType,
                RoomCapacity = a.RoomCapacity,
                RoomStatus = a.RoomStatus
            }));
            return Room_DetailDto;
        }

        // GET: api/Room_DetailData/FindRoomDetail/5
        [ResponseType(typeof(Room_Detail))]
        public IHttpActionResult FindRoomDetail(int id)
        {
            Room_Detail room_Detail = db.Room_Details.Find(id);
            Room_DetailDto room_DetailDto = new Room_DetailDto()
            {
                RoomID = room_Detail.RoomID,
                RoomNumber = room_Detail.RoomNumber,
                RoomType = room_Detail.RoomType,
                RoomCapacity = room_Detail.RoomCapacity,
                RoomStatus = room_Detail.RoomStatus
            };

            if (room_Detail == null)
            {
                return NotFound();
            }

            return Ok(room_Detail);
        }

        // POST: api/Room_DetailData/UpdateRoomDetail/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRoomDetails(int id, Room_Detail room_Detail)
        {
            Debug.WriteLine("I have reached the update room detail method");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_Detail.RoomID)
            {
                return BadRequest();
            }

            db.Entry(room_Detail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_DetailExists(id))
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

        // POST: api/Room_DetailData/AddRoomDetails/5
        [ResponseType(typeof(Room_Detail))]
        [HttpPost]
        public IHttpActionResult AddRoomDetail(Room_Detail room_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Room_Details.Add(room_Detail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room_Detail.RoomID }, room_Detail);
        }

        // DELETE: api/Room_DetailData/DeleteRoomDetail/5
        [ResponseType(typeof(Room_Detail))]
        [HttpPost]
        public IHttpActionResult DeleteRoomDetail(int id)
        {
            Room_Detail room_Detail = db.Room_Details.Find(id);
            if (room_Detail == null)
            {
                return NotFound();
            }

            db.Room_Details.Remove(room_Detail);
            db.SaveChanges();

            return Ok(room_Detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Room_DetailExists(int id)
        {
            return db.Room_Details.Count(e => e.RoomID == id) > 0;
        }
    }
}