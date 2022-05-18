namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "userPassword", c => c.String());
            DropForeignKey("dbo.Posts", "user_id", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "userId", "dbo.Users");
            DropForeignKey("dbo.UserRequests", "userId", "dbo.Users");
            RenameColumn(table: "dbo.Posts", name: "user_id", newName: "user_userId");
            RenameIndex(table: "dbo.Posts", name: "IX_user_id", newName: "IX_user_userId");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "id");
            DropColumn("dbo.Users", "firstName");
            DropColumn("dbo.Users", "lastName");
            DropColumn("dbo.Users", "profileImage");
            DropColumn("dbo.Users", "country");
            DropColumn("dbo.Users", "city");
            DropColumn("dbo.Users", "mobileNo");
            DropColumn("dbo.Users", "email");
            DropColumn("dbo.Users", "password");
            AddColumn("dbo.Users", "userId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "userFirstName", c => c.String());
            AddColumn("dbo.Users", "userLastName", c => c.String());
            AddColumn("dbo.Users", "userProfileImage", c => c.Binary());
            AddColumn("dbo.Users", "userCountry", c => c.String());
            AddColumn("dbo.Users", "userCity", c => c.String());
            AddColumn("dbo.Users", "userMobileNumber", c => c.Int());
            AddColumn("dbo.Users", "userEmail", c => c.String());

            AddPrimaryKey("dbo.Users", "userId");
            AddForeignKey("dbo.Posts", "user_userId", "dbo.Users", "userId");
            AddForeignKey("dbo.UserFriends", "userId", "dbo.Users", "userId", cascadeDelete: true);
            AddForeignKey("dbo.UserRequests", "userId", "dbo.Users", "userId", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "password", c => c.String());
            AddColumn("dbo.Users", "email", c => c.String());
            AddColumn("dbo.Users", "mobileNo", c => c.Int());
            AddColumn("dbo.Users", "city", c => c.String());
            AddColumn("dbo.Users", "country", c => c.String());
            AddColumn("dbo.Users", "profileImage", c => c.Binary());
            AddColumn("dbo.Users", "lastName", c => c.String());
            AddColumn("dbo.Users", "firstName", c => c.String());
            AddColumn("dbo.Users", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserRequests", "userId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "user_userId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "userPassword");
            DropColumn("dbo.Users", "userEmail");
            DropColumn("dbo.Users", "userMobileNumber");
            DropColumn("dbo.Users", "userCity");
            DropColumn("dbo.Users", "userCountry");
            DropColumn("dbo.Users", "userProfileImage");
            DropColumn("dbo.Users", "userLastName");
            DropColumn("dbo.Users", "userFirstName");
            DropColumn("dbo.Users", "userId");
            AddPrimaryKey("dbo.Users", "id");
            RenameIndex(table: "dbo.Posts", name: "IX_user_userId", newName: "IX_user_id");
            RenameColumn(table: "dbo.Posts", name: "user_userId", newName: "user_id");
            AddForeignKey("dbo.UserRequests", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserFriends", "userId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "user_id", "dbo.Users", "id");
        }
    }
}
