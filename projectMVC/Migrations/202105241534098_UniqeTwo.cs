namespace projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqeTwo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Drinks", new[] { "Code" });
            DropIndex("dbo.Foods", new[] { "Code" });
            DropIndex("dbo.Seets", new[] { "Code" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Seets", "Code", unique: true);
            CreateIndex("dbo.Foods", "Code", unique: true);
            CreateIndex("dbo.Drinks", "Code", unique: true);
        }
    }
}
