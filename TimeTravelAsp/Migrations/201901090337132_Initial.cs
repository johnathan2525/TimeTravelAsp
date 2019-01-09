namespace TimeTravelAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PositionInTime = c.DateTime(nullable: false),
                        Destination = c.String(nullable: false),
                        TransporterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transporters", t => t.TransporterId, cascadeDelete: true)
                .Index(t => t.TransporterId);
            
            CreateTable(
                "dbo.Transporters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "TransporterId", "dbo.Transporters");
            DropIndex("dbo.Passengers", new[] { "TransporterId" });
            DropTable("dbo.Transporters");
            DropTable("dbo.Passengers");
        }
    }
}
