namespace LibraryofBookis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookPublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JournalAuthors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Journals", t => t.JournalId, cascadeDelete: true)
                .Index(t => t.JournalId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JournalPublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalId = c.Int(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journals", t => t.JournalId, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .Index(t => t.JournalId)
                .Index(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.NewspaperAuthors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewspaperId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Newspapers", t => t.NewspaperId, cascadeDelete: true)
                .Index(t => t.NewspaperId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Newspapers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewspaperPublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewspaperId = c.Int(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Newspapers", t => t.NewspaperId, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .Index(t => t.NewspaperId)
                .Index(t => t.PublishingHouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewspaperPublishingHouses", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.NewspaperPublishingHouses", "NewspaperId", "dbo.Newspapers");
            DropForeignKey("dbo.NewspaperAuthors", "NewspaperId", "dbo.Newspapers");
            DropForeignKey("dbo.NewspaperAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.JournalPublishingHouses", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.JournalPublishingHouses", "JournalId", "dbo.Journals");
            DropForeignKey("dbo.JournalAuthors", "JournalId", "dbo.Journals");
            DropForeignKey("dbo.JournalAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookPublishingHouses", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.BookPublishingHouses", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors");
            DropIndex("dbo.NewspaperPublishingHouses", new[] { "PublishingHouseId" });
            DropIndex("dbo.NewspaperPublishingHouses", new[] { "NewspaperId" });
            DropIndex("dbo.NewspaperAuthors", new[] { "AuthorId" });
            DropIndex("dbo.NewspaperAuthors", new[] { "NewspaperId" });
            DropIndex("dbo.JournalPublishingHouses", new[] { "PublishingHouseId" });
            DropIndex("dbo.JournalPublishingHouses", new[] { "JournalId" });
            DropIndex("dbo.JournalAuthors", new[] { "AuthorId" });
            DropIndex("dbo.JournalAuthors", new[] { "JournalId" });
            DropIndex("dbo.BookPublishingHouses", new[] { "PublishingHouseId" });
            DropIndex("dbo.BookPublishingHouses", new[] { "BookId" });
            DropIndex("dbo.BookAuthors", new[] { "AuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "BookId" });
            DropTable("dbo.NewspaperPublishingHouses");
            DropTable("dbo.Newspapers");
            DropTable("dbo.NewspaperAuthors");
            DropTable("dbo.JournalPublishingHouses");
            DropTable("dbo.Journals");
            DropTable("dbo.JournalAuthors");
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.BookPublishingHouses");
            DropTable("dbo.Books");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Authors");
        }
    }
}
