namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "DateManufactured");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DateManufactured", c => c.DateTime());
            DropColumn("dbo.Products", "DateAdded");
        }
    }
}
