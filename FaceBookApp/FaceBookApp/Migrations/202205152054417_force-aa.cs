namespace FaceBookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forceaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "profileImage", c => c.Binary());
        }
    }
}
