namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoUinqe1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employes", new[] { "Code" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employes", "Code", unique: true);
        }
    }
}
