namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProblemShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProblemKendaraan", "Problem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProblemKendaraan", "Problem");
        }
    }
}
