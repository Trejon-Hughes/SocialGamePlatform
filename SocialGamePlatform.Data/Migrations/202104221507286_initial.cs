namespace SocialGamePlatform.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PoserID = c.Guid(nullable: false),
                        AccountId = c.Int(nullable: false),
                        PosterUserName = c.String(nullable: false),
                        Text = c.String(nullable: false, maxLength: 240),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewerId = c.Guid(nullable: false),
                        AccountId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        ReviewerUserName = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        StoryRating = c.Double(nullable: false),
                        GameplayRating = c.Double(nullable: false),
                        GraphicsRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        OwnerUserName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "GameId", "dbo.Game");
            DropForeignKey("dbo.Review", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Post", "AccountId", "dbo.Account");
            DropIndex("dbo.Review", new[] { "GameId" });
            DropIndex("dbo.Review", new[] { "AccountId" });
            DropIndex("dbo.Post", new[] { "AccountId" });
            DropTable("dbo.Game");
            DropTable("dbo.Review");
            DropTable("dbo.Post");
            DropTable("dbo.Account");
        }
    }
}
