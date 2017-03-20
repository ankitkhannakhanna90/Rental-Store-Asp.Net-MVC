namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSuperAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'3215ded0-0992-48d5-9736-45d8e77de7d9', N'superadmin@gmail.com', 0, N'AF9Xj3NopS68FgwPTU0QxBvzpw7MZHM9fANQ++AYlZnwGi/HveFao7egEhuEjEuUaA==', N'7c77ad00-3af7-494b-8619-b406adbffcc5', NULL, 0, 0, NULL, 0, 0, N'superadmin@gmail.com', N'Super Admin')
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9ebccdb6-f2ce-45d2-b8f5-01089d927803', N'SuperAdmin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3215ded0-0992-48d5-9736-45d8e77de7d9', N'9ebccdb6-f2ce-45d2-b8f5-01089d927803')
   
");  
        }
        
        public override void Down()
        {
        }
    }
}
