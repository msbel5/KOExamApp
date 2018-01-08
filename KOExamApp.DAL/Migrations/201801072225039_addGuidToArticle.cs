namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGuidToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Guid", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Guid");
        }
    }
}
