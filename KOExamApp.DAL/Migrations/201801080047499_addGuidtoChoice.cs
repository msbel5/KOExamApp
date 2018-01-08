namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGuidtoChoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Choices", "Guid", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Choices", "Guid");
        }
    }
}
