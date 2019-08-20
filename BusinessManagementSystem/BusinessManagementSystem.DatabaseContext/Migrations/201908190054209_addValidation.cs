namespace BusinessManagementSystem.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "ContactPerson", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Suppliers", "ContactPrson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "ContactPrson", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Suppliers", "ContactPerson");
        }
    }
}
