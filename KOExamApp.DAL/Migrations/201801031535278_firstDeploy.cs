namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstDeploy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Choices", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Choices", "IsSelected", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Choices", "Text", c => c.String());
        }
    }
}
