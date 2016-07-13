namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LapService", "Problem1", c => c.String());
            AddColumn("dbo.LapService", "Problem2", c => c.String());
            AddColumn("dbo.LapService", "Problem3", c => c.String());
            AddColumn("dbo.LapService", "Problem4", c => c.String());
            AddColumn("dbo.LapService", "Problem5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LapService", "Problem5");
            DropColumn("dbo.LapService", "Problem4");
            DropColumn("dbo.LapService", "Problem3");
            DropColumn("dbo.LapService", "Problem2");
            DropColumn("dbo.LapService", "Problem1");
        }
    }
}
