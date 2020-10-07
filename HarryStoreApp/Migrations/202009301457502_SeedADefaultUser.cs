namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedADefaultUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropColumn("dbo.Customers", "User_Id");
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
