namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RechangeAmountDataType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('AutoMobiles')");
            Sql("INSERT INTO Categories (Name) VALUES ('Stationary')");
            Sql("INSERT INTO Categories (Name) VALUES ('Gadget')");
            Sql("INSERT INTO Categories (Name) VALUES ('Wears')");
            Sql("INSERT INTO Categories (Name) VALUES ('FoodStuff')");
            Sql("INSERT INTO Categories (Name) VALUES ('Book')");
            Sql("INSERT INTO Categories (Name) VALUES ('Soaps')");
        }
        
        public override void Down()
        {
        }
    }
}
