namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassNotUNIQ3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cashers", new[] { "CasherPassword" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Cashers", "CasherPassword", unique: true);
        }
    }
}
