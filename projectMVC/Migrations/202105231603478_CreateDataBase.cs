namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
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
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Buy = c.Decimal(nullable: false, storeType: "money"),
                        Sale = c.Decimal(nullable: false, storeType: "money"),
                        Profit = c.Decimal(nullable: false, storeType: "money"),
                        Amonut = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Admin_Id);
            
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
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Buy = c.Decimal(nullable: false, storeType: "money"),
                        Sale = c.Decimal(nullable: false, storeType: "money"),
                        Profit = c.Decimal(nullable: false, storeType: "money"),
                        Amonut = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Seets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeetType = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.MultiSeets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seets", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.SingleSeets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seets", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleSeets", "ID", "dbo.Seets");
            DropForeignKey("dbo.MultiSeets", "ID", "dbo.Seets");
            DropForeignKey("dbo.Seets", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Foods", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Employes", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Drinks", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.SingleSeets", new[] { "ID" });
            DropIndex("dbo.MultiSeets", new[] { "ID" });
            DropIndex("dbo.Seets", new[] { "Admin_Id" });
            DropIndex("dbo.Seets", new[] { "Code" });
            DropIndex("dbo.Foods", new[] { "Admin_Id" });
            DropIndex("dbo.Foods", new[] { "Code" });
            DropIndex("dbo.Employes", new[] { "Admin_Id" });
            DropIndex("dbo.Employes", new[] { "CasherPassword" });
            DropIndex("dbo.Employes", new[] { "CasherUserName" });
            DropIndex("dbo.Employes", new[] { "Code" });
            DropIndex("dbo.Drinks", new[] { "Admin_Id" });
            DropIndex("dbo.Drinks", new[] { "Code" });
            DropIndex("dbo.Admins", new[] { "CasherPassword" });
            DropIndex("dbo.Admins", new[] { "CasherUserName" });
            DropIndex("dbo.Admins", new[] { "Code" });
            DropIndex("dbo.Admins", new[] { "AdminPassword" });
            DropIndex("dbo.Admins", new[] { "AdminUserName" });
            DropTable("dbo.SingleSeets");
            DropTable("dbo.MultiSeets");
            DropTable("dbo.Seets");
            DropTable("dbo.Foods");
            DropTable("dbo.Employes");
            DropTable("dbo.Drinks");
            DropTable("dbo.Admins");
        }
    }
}
