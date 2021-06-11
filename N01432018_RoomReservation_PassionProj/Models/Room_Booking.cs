using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N01432018_RoomReservation_PassionProj.Models
{
    public class Room_Booking
    {
        [Key]
        public int BookingID { get; set; }
        public string BookingName { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        /// <summary>
        /// Connect this table to room_details details because the
        /// A room can be share by two person at the same time
        /// So,Booking_Room has the connection with the Room_Details
        /// RoomID will be the foreign key.
        /// </summary>
        /// 
        //Specify that this Foreign key is of Room_Detail entity
        //A room associated with more than one person.
        //One person belongs to one room.
        [ForeignKey("Room_Detail")]
        public int RoomID { get; set; }
        public virtual Room_Detail Room_Detail { get; set; }
    }

    //Data transfer object
    public class Room_BookingDto
    {
        [Key]
        public int BookingID { get; set; }
        public string BookingName { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        public int RoomNumber { get; set; }
    }
}