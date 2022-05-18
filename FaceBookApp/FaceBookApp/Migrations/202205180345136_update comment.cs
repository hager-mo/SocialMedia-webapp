namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecomment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            DropColumn("dbo.Comments", "Id");
            DropColumn("dbo.Comments", "Text");
            DropColumn("dbo.Comments", "author");
            AddColumn("dbo.Comments", "commentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Comments", "commentContent", c => c.String());
            AddColumn("dbo.Comments", "commentAuthor", c => c.String());
            AddPrimaryKey("dbo.Comments", "commentId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "author", c => c.String());
            AddColumn("dbo.Comments", "Text", c => c.String());
            AddColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Comments");
            DropColumn("dbo.Comments", "commentAuthor");
            DropColumn("dbo.Comments", "commentContent");
            DropColumn("dbo.Comments", "commentId");
            AddPrimaryKey("dbo.Comments", "Id");
        }
    }
}
