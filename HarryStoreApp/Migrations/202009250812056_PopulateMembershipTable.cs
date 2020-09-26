namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes( Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('PayAsYouGo',0,0,0) ");
            Sql("INSERT INTO MembershipTypes( Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Monthly',200,1,10) ");
            Sql("INSERT INTO MembershipTypes( Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Quartely',500,4,30) ");
            Sql("INSERT INTO MembershipTypes( Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Annually',1000,12,50) ");
        }
        
        public override void Down()
        {
        }
    }
}
