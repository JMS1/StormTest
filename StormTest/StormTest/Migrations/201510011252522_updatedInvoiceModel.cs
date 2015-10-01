namespace StormTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedInvoiceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Supplier", c => c.String());
            AddColumn("dbo.Invoices", "InvoiceTotal", c => c.Double(nullable: false));
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            DropColumn("dbo.Invoices", "InvoiceTotal");
            DropColumn("dbo.Invoices", "Supplier");
        }
    }
}
