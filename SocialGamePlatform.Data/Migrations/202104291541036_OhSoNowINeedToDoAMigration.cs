namespace SocialGamePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OhSoNowINeedToDoAMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Rating", c => c.Double(nullable: false));
        }
    }
}
