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
using N01432018_RoomReservation_PassionProj.Models;
using System.Diagnostics;


namespace N01432018_RoomReservation_PassionProj.Controllers
{
    public class Room_BookingDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Room_BookingData/ListRoomBookings
        [HttpGet]
        public IEnumerable<Room_BookingDto> ListRoomBookings()
        {
            List<Room_Booking> Room_Bookings = db.Room_Bookings.ToList();
            List<Room_BookingDto> Room_BookingDto = new List<Room_BookingDto>();

            Room_Bookings.ForEach(a => Room_BookingDto.Add(new Room_BookingDto()
            {
                BookingID = a.BookingID,
                BookingName = a.BookingName,
                DateIn = a.DateIn,
                DateOut = a.DateOut,
                RoomNumber = a.Room_Detail.RoomNumber
            }));
            return Room_BookingDto;
        }

        //Find the room with RoomID = 2
        // GET: api/Room_BookingData/FindRoomBooking/2
        [ResponseType(typeof(Room_Booking))]
        [HttpGet]
        public IHttpActionResult FindRoomBooking(int id)
        {
            Room_Booking room_Booking = db.Room_Bookings.Find(id);
            Room_BookingDto room_BookingDto = new Room_BookingDto()
            {
                BookingID = room_Booking.BookingID,
                BookingName = room_Booking.BookingName,
                DateIn = room_Booking.DateIn,
                DateOut = room_Booking.DateOut,
                RoomNumber = room_Booking.Room_Detail.RoomNumber
            };

            if (room_Booking == null)
            {
                return NotFound();
            }

            return Ok(room_Booking);
        }

        //Update the perticular room_booking details
        //Update the Room_booking with RoomID =5
        // POST: api/Room_BookingData/UpdateRoomBooking/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRoomBooking(int id, Room_Booking room_Booking)
        {
            Debug.WriteLine("I have reached the update room booking method");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_Booking.BookingID)
            {
                return BadRequest();
            }

            db.Entry(room_Booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_BookingExists(id))
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

        // POST: api/Room_BookingData/AddRoomBooking
        [ResponseType(typeof(Room_Booking))]
        [HttpPost]
        public IHttpActionResult AddRoomBooking(Room_Booking room_Booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Room_Bookings.Add(room_Booking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room_Booking.BookingID }, room_Booking);
        }

        //POST : DELETE: api/Room_BookingData/DeleteRoomBooking/5
        [ResponseType(typeof(Room_Booking))]
        [HttpPost]
        public IHttpActionResult DeleteRoomBooking(int id)
        {
            Room_Booking room_Booking = db.Room_Bookings.Find(id);
            if (room_Booking == null)
            {
                return NotFound();
            }

            db.Room_Bookings.Remove(room_Booking);
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

        private bool Room_BookingExists(int id)
        {
            return db.Room_Bookings.Count(e => e.BookingID == id) > 0;
        }
    }
}