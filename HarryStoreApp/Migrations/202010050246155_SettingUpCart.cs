namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingUpCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OrderItem_Id", "dbo.OrderItems");
            DropIndex("dbo.Products", new[] { "OrderItem_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Cart_Id", newName: "CartId");
            RenameIndex(table: "dbo.OrderItems", name: "IX_Cart_Id", newName: "IX_CartId");
            AddColumn("dbo.OrderItems", "productId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "productId");
            AddForeignKey("dbo.OrderItems", "productId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "OrderItem_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OrderItem_Id", c => c.Int());
            DropForeignKey("dbo.OrderItems", "productId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "productId" });
            DropColumn("dbo.OrderItems", "productId");
            RenameIndex(table: "dbo.OrderItems", name: "IX_CartId", newName: "IX_Cart_Id");
            RenameColumn(table: "dbo.OrderItems", name: "CartId", newName: "Cart_Id");
            CreateIndex("dbo.Products", "OrderItem_Id");
            AddForeignKey("dbo.Products", "OrderItem_Id", "dbo.OrderItems", "Id");
        }
    }
}
