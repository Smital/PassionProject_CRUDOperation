using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace N01432018_RoomReservation_PassionProj.Models
{
    public class Room_Amenity
    {
        [Key]
        public int AmenityID { get; set; }
        public string AmenityName { get; set; }

        //An Amenity is associated with many rooms
        public ICollection<Room_Detail> Room_Details { get; set; }
    }

    public class Room_AmenityDto
    {
        [Key]
        public int AmenityID { get; set; }
        public string AmenityName { get; set; }

        internal static void Add(Room_AmenityDto room_AmenityDto)
        {
            throw new NotImplementedException();
        }
    }
}