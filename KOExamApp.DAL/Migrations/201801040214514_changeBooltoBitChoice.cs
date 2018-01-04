namespace KOExamApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBooltoBitChoice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "IsAnswer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Choices", "IsAnswer", c => c.Boolean(nullable: false));
        }
    }
}
