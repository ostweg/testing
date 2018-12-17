namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "EndDate", c => c.DateTime());
            DropColumn("dbo.Rentals", "returned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "returned", c => c.Boolean(nullable: false));
            DropColumn("dbo.Rentals", "EndDate");
        }
    }
}
