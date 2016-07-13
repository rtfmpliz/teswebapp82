namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kendaraan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NoPol = c.String(),
                        TipeKendaraan = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LapService",
                c => new
                    {
                        LapServiceID = c.Int(nullable: false, identity: true),
                        KendaraanID = c.Int(nullable: false),
                        Perkiraan = c.Int(nullable: false),
                        Waktu = c.DateTime(nullable: false),
                        Bengkel = c.String(),
                        AlamatTelp = c.String(),
                        Keterangan = c.String(),
                    })
                .PrimaryKey(t => t.LapServiceID)
                .ForeignKey("dbo.Kendaraan", t => t.KendaraanID, cascadeDelete: true)
                .Index(t => t.KendaraanID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LapService", "KendaraanID", "dbo.Kendaraan");
            DropIndex("dbo.LapService", new[] { "KendaraanID" });
            DropTable("dbo.LapService");
            DropTable("dbo.Kendaraan");
        }
    }
}
