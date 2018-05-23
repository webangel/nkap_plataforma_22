namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPRINT02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Dni", c => c.String(nullable: false, maxLength: 8, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Dni", c => c.String(maxLength: 8, unicode: false));
        }
    }
}
