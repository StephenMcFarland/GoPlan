namespace GoPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacation", "Attendees", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacation", "Attendees");
        }
    }
}
