namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forcead : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.String(nullable: false));
        }
    }
}
