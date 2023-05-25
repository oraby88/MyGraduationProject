namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrobSeetsR : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultiSeets", "ID", "dbo.Seets");
            DropForeignKey("dbo.SingleSeets", "ID", "dbo.Seets");
            DropIndex("dbo.MultiSeets", new[] { "ID" });
            DropIndex("dbo.SingleSeets", new[] { "ID" });
            AddColumn("dbo.Seets", "IsEmpty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Seets", "Cost", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Seets", "StartTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Seets", "EndTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropTable("dbo.MultiSeets");
            DropTable("dbo.SingleSeets");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Seets", "EndTime");
            DropColumn("dbo.Seets", "StartTime");
            DropColumn("dbo.Seets", "Cost");
            DropColumn("dbo.Seets", "IsEmpty");
            CreateIndex("dbo.SingleSeets", "ID");
            CreateIndex("dbo.MultiSeets", "ID");
            AddForeignKey("dbo.SingleSeets", "ID", "dbo.Seets", "Id");
            AddForeignKey("dbo.MultiSeets", "ID", "dbo.Seets", "Id");
        }
    }
}
