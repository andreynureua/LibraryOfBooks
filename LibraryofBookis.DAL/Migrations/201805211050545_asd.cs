namespace LibraryofBookis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Namef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Namef");
        }
    }
}
