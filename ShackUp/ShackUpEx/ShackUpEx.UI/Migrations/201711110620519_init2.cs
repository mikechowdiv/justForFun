namespace ShackUpEx.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "StateId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "StateId", c => c.Int(nullable: false));
        }
    }
}
