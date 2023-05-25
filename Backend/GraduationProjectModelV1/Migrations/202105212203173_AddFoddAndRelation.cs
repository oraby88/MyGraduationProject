namespace GraduationProjectModelV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoddAndRelation : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.Foods", new[] { "Admin_Id" });
            DropIndex("dbo.Foods", new[] { "Code" });
            DropTable("dbo.Foods");
        }
    }
}
