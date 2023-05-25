namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassNotUNIQ5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cashers", "Emp_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cashers", "Emp_Id");
            AddForeignKey("dbo.Cashers", "Emp_Id", "dbo.Employes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cashers", "Emp_Id", "dbo.Employes");
            DropIndex("dbo.Cashers", new[] { "Emp_Id" });
            DropColumn("dbo.Cashers", "Emp_Id");
        }
    }
}
