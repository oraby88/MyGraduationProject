namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCasher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cashers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CasherUserName = c.String(nullable: false, maxLength: 100),
                        CasherPassword = c.String(nullable: false, maxLength: 100),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.CasherUserName, unique: true)
                .Index(t => t.CasherPassword, unique: true)
                .Index(t => t.Admin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cashers", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.Cashers", new[] { "Admin_Id" });
            DropIndex("dbo.Cashers", new[] { "CasherPassword" });
            DropIndex("dbo.Cashers", new[] { "CasherUserName" });
            DropTable("dbo.Cashers");
        }
    }
}
