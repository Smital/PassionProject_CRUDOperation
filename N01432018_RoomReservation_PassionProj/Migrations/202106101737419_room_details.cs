namespace N01432018_RoomReservation_PassionProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class room_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room_Detail",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        RoomType = c.String(),
                        RoomCapacity = c.Int(nullable: false),
                        RoomStatus = c.String(),
                    })
                .PrimaryKey(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Room_Detail");
        }
    }
}
