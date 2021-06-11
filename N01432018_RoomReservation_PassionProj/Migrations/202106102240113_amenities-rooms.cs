namespace N01432018_RoomReservation_PassionProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amenitiesrooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room_Amenity",
                c => new
                    {
                        AmenityID = c.Int(nullable: false, identity: true),
                        AmenityName = c.String(),
                    })
                .PrimaryKey(t => t.AmenityID);
            
            CreateTable(
                "dbo.Room_AmenityRoom_Detail",
                c => new
                    {
                        Room_Amenity_AmenityID = c.Int(nullable: false),
                        Room_Detail_RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Amenity_AmenityID, t.Room_Detail_RoomID })
                .ForeignKey("dbo.Room_Amenity", t => t.Room_Amenity_AmenityID, cascadeDelete: true)
                .ForeignKey("dbo.Room_Detail", t => t.Room_Detail_RoomID, cascadeDelete: true)
                .Index(t => t.Room_Amenity_AmenityID)
                .Index(t => t.Room_Detail_RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room_AmenityRoom_Detail", "Room_Detail_RoomID", "dbo.Room_Detail");
            DropForeignKey("dbo.Room_AmenityRoom_Detail", "Room_Amenity_AmenityID", "dbo.Room_Amenity");
            DropIndex("dbo.Room_AmenityRoom_Detail", new[] { "Room_Detail_RoomID" });
            DropIndex("dbo.Room_AmenityRoom_Detail", new[] { "Room_Amenity_AmenityID" });
            DropTable("dbo.Room_AmenityRoom_Detail");
            DropTable("dbo.Room_Amenity");
        }
    }
}
