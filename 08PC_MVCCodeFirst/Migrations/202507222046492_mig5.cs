namespace _08PC_MVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
        }
    }
}
