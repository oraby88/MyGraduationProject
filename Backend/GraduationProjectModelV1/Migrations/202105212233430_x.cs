namespace GraduationProjectModelV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MultiSeets", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.SingleSeets", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.MultiSeets", new[] { "Admin_Id" });
            DropIndex("dbo.SingleSeets", new[] { "Admin_Id" });
            DropColumn("dbo.MultiSeets", "Admin_Id");
            DropColumn("dbo.SingleSeets", "Admin_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SingleSeets", "Admin_Id", c => c.Int());
            AddColumn("dbo.MultiSeets", "Admin_Id", c => c.Int());
            CreateIndex("dbo.SingleSeets", "Admin_Id");
            CreateIndex("dbo.MultiSeets", "Admin_Id");
            AddForeignKey("dbo.SingleSeets", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.MultiSeets", "Admin_Id", "dbo.Admins", "Id");
        }
    }
}
