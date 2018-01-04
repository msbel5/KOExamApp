namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addarticle : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Exams", "ArticleId");
            AddForeignKey("dbo.Exams", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Exams", new[] { "ArticleId" });
        }
    }
}
