namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TambahProblemTrial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemKendaraan",
                c => new
                    {
                        ProblemKendaraanId = c.Int(nullable: false, identity: true),
                        LapServiceID = c.Int(nullable: false),
                        Problem = c.String(),
                        Status = c.Boolean(nullable: false),
                        Jadwal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProblemKendaraanId)
                .ForeignKey("dbo.LapService", t => t.LapServiceID, cascadeDelete: true)
                .Index(t => t.LapServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProblemKendaraan", "LapServiceID", "dbo.LapService");
            DropIndex("dbo.ProblemKendaraan", new[] { "LapServiceID" });
            DropTable("dbo.ProblemKendaraan");
        }
    }
}
