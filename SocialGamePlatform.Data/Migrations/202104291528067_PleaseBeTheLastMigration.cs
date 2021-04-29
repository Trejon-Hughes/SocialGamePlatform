namespace SocialGamePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PleaseBeTheLastMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "Rating");
        }
    }
}
