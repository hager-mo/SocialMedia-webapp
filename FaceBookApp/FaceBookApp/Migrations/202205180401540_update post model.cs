namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepostmodel : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.Posts", "userId", "dbo.Users");
    
            DropIndex("dbo.Posts", new[] { "userId" });
            RenameColumn(table: "dbo.Posts", name: "userId", newName: "user_id");
            DropPrimaryKey("dbo.Posts");
            DropColumn("dbo.Posts", "id");
            DropColumn("dbo.Posts", "content");
            DropColumn("dbo.Posts", "hidden");
            DropColumn("dbo.Posts", "likes");
            DropColumn("dbo.Posts", "dislikes");
            AddColumn("dbo.Posts", "postId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Posts", "postContent", c => c.String());
            AddColumn("dbo.Posts", "postHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "postLikes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "postDislikes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "postAuthor", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "user_id", c => c.Int());
            AddPrimaryKey("dbo.Posts", "postId");
            CreateIndex("dbo.Posts", "user_id");
            AddForeignKey("dbo.Posts", "user_id", "dbo.Users", "id");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "dislikes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "likes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "content", c => c.String());
            AddColumn("dbo.Posts", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Posts", "user_id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "user_id" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "user_id", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "postAuthor");
            DropColumn("dbo.Posts", "postDislikes");
            DropColumn("dbo.Posts", "postLikes");
            DropColumn("dbo.Posts", "postHidden");
            DropColumn("dbo.Posts", "postContent");
            DropColumn("dbo.Posts", "postId");
            AddPrimaryKey("dbo.Posts", "id");
            RenameColumn(table: "dbo.Posts", name: "user_id", newName: "userId");
            CreateIndex("dbo.Posts", "userId");
            AddForeignKey("dbo.Posts", "userId", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
