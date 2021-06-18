namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Rate = c.Byte(nullable: false),
                        Review = c.String(nullable: false, maxLength: 100),
                        SongID = c.Int(nullable: false),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .ForeignKey("dbo.Songs", t => t.SongID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SongID)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        YearReleased = c.Short(nullable: false),
                        Lenght = c.Single(nullable: false),
                        Rating_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ratings", t => t.Rating_Id)
                .Index(t => t.Rating_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Byte(nullable: false),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Songs", "Rating_Id", "dbo.Ratings");
            DropForeignKey("dbo.Ratings", "SongID", "dbo.Songs");
            DropForeignKey("dbo.Ratings", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "Rating_Id" });
            DropIndex("dbo.Ratings", new[] { "Song_Id" });
            DropIndex("dbo.Ratings", new[] { "SongID" });
            DropIndex("dbo.Ratings", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Songs");
            DropTable("dbo.Ratings");
        }
    }
}
