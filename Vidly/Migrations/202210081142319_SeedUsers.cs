namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7e99162e-e142-4e45-b1b1-703f15a37635', N'admin@vidly.com', 0, N'AJWZ2mjf9FvIH43sKr08HSdERb+TXqHckV/7Afyq69uFJvCIXjWceK4xhZ2gVvzOFQ==', N'aaebf27e-6e0d-4de8-bf77-4422505a866f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a8ea9e52-d114-4e99-88d5-6c9680874753', N'guest@vidly.com', 0, N'ACYV93RDMW5+pDA9DS9SDNkoI5yUhDkuXsqJDewYtMU7Gvv0oaPA9PGob9OFXBOLAw==', N'baf9feb0-6211-49bb-b9aa-1574d9f7c8a0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e6e4db5f-316d-45eb-8983-87e476f193e0', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7e99162e-e142-4e45-b1b1-703f15a37635', N'e6e4db5f-316d-45eb-8983-87e476f193e0')
");
        }
        
        public override void Down()
        {
        }
    }
}
