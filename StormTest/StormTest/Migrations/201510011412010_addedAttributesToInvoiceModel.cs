namespace StormTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAttributesToInvoiceModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "Supplier", c => c.String(nullable: false));
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Invoices", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Description", c => c.String());
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String());
            AlterColumn("dbo.Invoices", "Supplier", c => c.String());
        }
    }
}
