namespace GraduationProjectModelV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeetAndRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MultiSeets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seets", t => t.ID)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.ID)
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
                "dbo.SingleSeets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seets", t => t.ID)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.ID)
                .Index(t => t.Admin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleSeets", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.MultiSeets", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.MultiSeets", "ID", "dbo.Seets");
            DropForeignKey("dbo.SingleSeets", "ID", "dbo.Seets");
            DropForeignKey("dbo.Seets", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.SingleSeets", new[] { "Admin_Id" });
            DropIndex("dbo.SingleSeets", new[] { "ID" });
            DropIndex("dbo.Seets", new[] { "Admin_Id" });
            DropIndex("dbo.Seets", new[] { "Code" });
            DropIndex("dbo.MultiSeets", new[] { "Admin_Id" });
            DropIndex("dbo.MultiSeets", new[] { "ID" });
            DropTable("dbo.SingleSeets");
            DropTable("dbo.Seets");
            DropTable("dbo.MultiSeets");
        }
    }
}
