namespace LibraryofBookis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadsa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Namef");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Namef", c => c.String());
        }
    }
}
