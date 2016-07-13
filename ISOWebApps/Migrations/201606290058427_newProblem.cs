namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newProblem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProblemKendaraan", "LapServiceID", "dbo.LapService");
            DropIndex("dbo.ProblemKendaraan", new[] { "LapServiceID" });
            RenameColumn(table: "dbo.ProblemKendaraan", name: "LapServiceID", newName: "LapService_LapServiceID");
            AddColumn("dbo.ProblemKendaraan", "JadwalTunda", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProblemKendaraan", "LapService_LapServiceID", c => c.Int());
            CreateIndex("dbo.ProblemKendaraan", "LapService_LapServiceID");
            AddForeignKey("dbo.ProblemKendaraan", "LapService_LapServiceID", "dbo.LapService", "LapServiceID");
            DropColumn("dbo.ProblemKendaraan", "Problem");
            DropColumn("dbo.ProblemKendaraan", "Jadwal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProblemKendaraan", "Jadwal", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProblemKendaraan", "Problem", c => c.String());
            DropForeignKey("dbo.ProblemKendaraan", "LapService_LapServiceID", "dbo.LapService");
            DropIndex("dbo.ProblemKendaraan", new[] { "LapService_LapServiceID" });
            AlterColumn("dbo.ProblemKendaraan", "LapService_LapServiceID", c => c.Int(nullable: false));
            DropColumn("dbo.ProblemKendaraan", "JadwalTunda");
            RenameColumn(table: "dbo.ProblemKendaraan", name: "LapService_LapServiceID", newName: "LapServiceID");
            CreateIndex("dbo.ProblemKendaraan", "LapServiceID");
            AddForeignKey("dbo.ProblemKendaraan", "LapServiceID", "dbo.LapService", "LapServiceID", cascadeDelete: true);
        }
    }
}
