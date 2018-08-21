namespace Ghost.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ghostt", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Ghostt", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Ghostt", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ghostt", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Ghostt", "Content");
            DropColumn("dbo.Ghostt", "Title");
        }
    }
}
