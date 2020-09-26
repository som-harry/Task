namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateManufactured", c => c.DateTime());
            AlterColumn("dbo.Products", "DateToExpire", c => c.DateTime());
            AlterColumn("dbo.Products", "NumberAvailable", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "NumberAvailable", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DateToExpire", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateManufactured", c => c.DateTime(nullable: false));
        }
    }
}
