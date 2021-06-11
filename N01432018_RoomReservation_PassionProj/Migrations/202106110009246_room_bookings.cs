namespace N01432018_RoomReservation_PassionProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class room_bookings : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Booking_Room", newName: "Room_Booking");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Room_Booking", newName: "Booking_Room");
        }
    }
}
