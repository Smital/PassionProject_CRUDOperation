using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace N01432018_RoomReservation_PassionProj.Models
{
    public class Room_Detail
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomStatus { get; set; }

        //Each room has more than one Amenities
        public ICollection<Room_Amenity> Room_Amenities { get; set; }


    }

    public class Room_DetailDto
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomStatus { get; set; }
        
    }
}