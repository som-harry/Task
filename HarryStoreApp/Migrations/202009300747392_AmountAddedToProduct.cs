namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmountAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Amount");
        }
    }
}
