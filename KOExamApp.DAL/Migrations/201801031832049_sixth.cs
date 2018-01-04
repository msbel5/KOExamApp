namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "Name");
        }
    }
}
