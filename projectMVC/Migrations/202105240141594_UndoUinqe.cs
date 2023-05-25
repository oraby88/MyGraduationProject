namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoUinqe : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employes", new[] { "CasherUserName" });
            DropIndex("dbo.Employes", new[] { "CasherPassword" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Employes", "CasherPassword", unique: true);
            CreateIndex("dbo.Employes", "CasherUserName", unique: true);
        }
    }
}
