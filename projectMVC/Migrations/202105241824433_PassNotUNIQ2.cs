namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassNotUNIQ2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Admins", new[] { "CasherUserName" });
            DropColumn("dbo.Admins", "CasherUserName");
            DropColumn("dbo.Admins", "CasherPassword");
            DropColumn("dbo.Employes", "CasherUserName");
            DropColumn("dbo.Employes", "CasherPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "CasherPassword", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Employes", "CasherUserName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Admins", "CasherPassword", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Admins", "CasherUserName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Admins", "CasherUserName", unique: true);
        }
    }
}
