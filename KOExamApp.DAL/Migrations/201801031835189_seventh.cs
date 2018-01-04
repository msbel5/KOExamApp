namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Exams", new[] { "ArticleId" });
            DropColumn("dbo.Exams", "ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "ArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exams", "ArticleId");
            AddForeignKey("dbo.Exams", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
