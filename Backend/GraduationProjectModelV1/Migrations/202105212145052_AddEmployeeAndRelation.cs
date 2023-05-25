namespace GraduationProjectModelV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeAndRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        Job = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 70),
                        Code = c.String(nullable: false, maxLength: 100),
                        EmployeType = c.Int(nullable: false),
                        CasherUserName = c.String(nullable: false, maxLength: 100),
                        CasherPassword = c.String(nullable: false, maxLength: 100),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CasherUserName, unique: true)
                .Index(t => t.CasherPassword, unique: true)
                .Index(t => t.Admin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.Employes", new[] { "Admin_Id" });
            DropIndex("dbo.Employes", new[] { "CasherPassword" });
            DropIndex("dbo.Employes", new[] { "CasherUserName" });
            DropIndex("dbo.Employes", new[] { "Code" });
            DropTable("dbo.Employes");
        }
    }
}
