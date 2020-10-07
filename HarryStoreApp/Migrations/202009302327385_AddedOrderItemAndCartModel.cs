namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderItemAndCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "OrderItem_Id", c => c.Int());
            CreateIndex("dbo.Products", "OrderItem_Id");
            AddForeignKey("dbo.Products", "OrderItem_Id", "dbo.OrderItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OrderItem_Id", "dbo.OrderItems");
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "OrderItem_Id" });
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropColumn("dbo.Products", "OrderItem_Id");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Carts");
        }
    }
}
