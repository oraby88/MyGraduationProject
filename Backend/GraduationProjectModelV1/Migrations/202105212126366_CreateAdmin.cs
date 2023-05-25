namespace GraduationProjectModelV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(nullable: false, maxLength: 100),
                        AdminPassword = c.String(nullable: false, maxLength: 100),
                        BussinesType = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        CasherUserName = c.String(nullable: false, maxLength: 100),
                        CasherPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.AdminUserName, unique: true)
                .Index(t => t.AdminPassword, unique: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CasherUserName, unique: true)
                .Index(t => t.CasherPassword, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Admins", new[] { "CasherPassword" });
            DropIndex("dbo.Admins", new[] { "CasherUserName" });
            DropIndex("dbo.Admins", new[] { "Code" });
            DropIndex("dbo.Admins", new[] { "AdminPassword" });
            DropIndex("dbo.Admins", new[] { "AdminUserName" });
            DropTable("dbo.Admins");
        }
    }
}
