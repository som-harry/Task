namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a8353d4-a065-4348-a4e2-7534c52518c0', N'mike1234@gmail.com', 0, N'ANnrDPk28EQ/D0TWd+5AFxkv+zdQ9O8bUbiVjxHHS9RiXxXSUgzwRPg4KMOYye4MvQ==', N'b27e33c2-c093-472e-8ea5-a197d9943824', NULL, 0, 0, NULL, 1, 0, N'mike1234@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4346e7a-4695-4aff-bb0a-f107c04d3563', N'Admin123456@gmail.com', 0, N'AM9rxiYgNJkIjx8MM+dTdU9dikMgmXIKXwB4ClDvBAXsQaaRgKWDfm5S6id+dFZuRA==', N'8317cda3-4d5f-4f9a-9ac2-3325207a88dc', NULL, 0, 0, NULL, 1, 0, N'Admin123456@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4688ff60-a38c-4c0e-8207-18b124be4213', N'CanManageCustomers')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4346e7a-4695-4aff-bb0a-f107c04d3563', N'4688ff60-a38c-4c0e-8207-18b124be4213')

");
        }
        
        public override void Down()
        {
        }
    }
}
