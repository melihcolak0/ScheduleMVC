namespace _08PC_MVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Events", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CategoryId");
            AddForeignKey("dbo.Events", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "CategoryId" });
            DropColumn("dbo.Events", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
