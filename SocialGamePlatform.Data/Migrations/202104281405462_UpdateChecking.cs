namespace SocialGamePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateChecking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "PosterID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Game", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Post", "PoserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "PoserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Game", "Description", c => c.String());
            DropColumn("dbo.Post", "PosterID");
        }
    }
}
