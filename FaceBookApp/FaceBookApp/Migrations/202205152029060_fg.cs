namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PostNum = c.Int(nullable: false),
                        author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        hidden = c.Boolean(nullable: false),
                        likes = c.Int(nullable: false),
                        dislikes = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        profileImage = c.Binary(),
                        country = c.String(),
                        city = c.String(),
                        mobileNo = c.Int(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        friendId = c.Int(nullable: false),
                        friend = c.String(),
                    })
                .PrimaryKey(t => new { t.userId, t.friendId })
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        requestId = c.Int(nullable: false),
                        request = c.String(),
                    })
                .PrimaryKey(t => new { t.userId, t.requestId })
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequests", "userId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "userId", "dbo.Users");
            DropIndex("dbo.UserRequests", new[] { "userId" });
            DropIndex("dbo.UserFriends", new[] { "userId" });
            DropIndex("dbo.Posts", new[] { "userId" });
            DropTable("dbo.UserRequests");
            DropTable("dbo.UserFriends");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
