namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableInCartKey1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "CartId", "dbo.Carts");
            DropIndex("dbo.OrderItems", new[] { "CartId" });
            AlterColumn("dbo.OrderItems", "CartId", c => c.Int());
            CreateIndex("dbo.OrderItems", "CartId");
            AddForeignKey("dbo.OrderItems", "CartId", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "CartId", "dbo.Carts");
            DropIndex("dbo.OrderItems", new[] { "CartId" });
            AlterColumn("dbo.OrderItems", "CartId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "CartId");
            AddForeignKey("dbo.OrderItems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
