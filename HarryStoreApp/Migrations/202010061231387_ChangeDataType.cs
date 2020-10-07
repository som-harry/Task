namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "productId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "productId" });
            AlterColumn("dbo.OrderItems", "productId", c => c.Int());
            CreateIndex("dbo.OrderItems", "productId");
            AddForeignKey("dbo.OrderItems", "productId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "productId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "productId" });
            AlterColumn("dbo.OrderItems", "productId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "productId");
            AddForeignKey("dbo.OrderItems", "productId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
