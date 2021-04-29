namespace SocialGamePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalCheck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        AchievementId = c.Int(nullable: false, identity: true),
                        CreatorId = c.Guid(nullable: false),
                        GameId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AchievementId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            AddColumn("dbo.Review", "GameName", c => c.String());
            AlterColumn("dbo.Review", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achievement", "GameId", "dbo.Game");
            DropIndex("dbo.Achievement", new[] { "GameId" });
            AlterColumn("dbo.Review", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Review", "GameName");
            DropTable("dbo.Achievement");
        }
    }
}
