namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userDataLatest : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f3b96b7-d14d-48ea-a21c-6c244b0becef', N'admin@movie.com', 0, N'AG3jr5A5SX3q9KGgAcXog8/CUC3cevrCf6uMztBpmHGZQ5X5nV650YbM01BtCKhAYw==', N'02e58903-b3ac-4816-b46f-8631b46607cf', NULL, 0, 0, NULL, 1, 0, N'admin@movie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7be75ad2-ade1-4a4a-b626-d462b9ae21e4', N'ashishaswani0708@gmail.com', 0, N'AEKLsoHYXHCvoGC22pNScxXmWMBkurtbvUWL/CUMo//5hKHlsat6AwJ2zVominQHpg==', N'2eda6a94-2df3-414e-a3a2-1243d0cac716', NULL, 0, 0, NULL, 1, 0, N'ashishaswani0708@gmail.com')
 INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'542c7ec6-75b1-420d-be9d-214ffb086c25', N'admin')
 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f3b96b7-d14d-48ea-a21c-6c244b0becef', N'542c7ec6-75b1-420d-be9d-214ffb086c25')
");
        }
        
        public override void Down()
        {
        }
    }
}
