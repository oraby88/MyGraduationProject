namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassNotUNIQ : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Admins", new[] { "AdminPassword" });
            DropIndex("dbo.Admins", new[] { "CasherPassword" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Admins", "CasherPassword", unique: true);
            CreateIndex("dbo.Admins", "AdminPassword", unique: true);
        }
    }
}
