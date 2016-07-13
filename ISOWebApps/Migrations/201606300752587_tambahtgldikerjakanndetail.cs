namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahtgldikerjakanndetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProblemKendaraan", "TglDikerjakan", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProblemKendaraan", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProblemKendaraan", "Detail");
            DropColumn("dbo.ProblemKendaraan", "TglDikerjakan");
        }
    }
}
