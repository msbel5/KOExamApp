namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addArticleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "ArticleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "ArticleId");
        }
    }
}
