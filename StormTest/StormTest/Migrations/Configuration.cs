namespace StormTest.Migrations
{
    using LinqToExcel;
    using StormTest.Context;
    using StormTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StormTest.Utility;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<StormTest.Context.SupplierContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StormTest.Context.SupplierContext context)
        {

            SupplierContext db = new SupplierContext();
            var excelFile = new ExcelQueryFactory(@"C:\Users\James\Downloads\Technical Test - Data.xlsx");
            excelFile.WorksheetRange("B2", "H12");

            var query = from row in excelFile.Worksheet("Data")
                        select new Invoice()
                            {
                                Supplier = row["Supplier Name"].Cast<string>(),
                                InvoiceType = row["Invoice Type"].Cast<string>(),
                                InvoiceNumber = row["Invoice Number"].Cast<string>(),
                                PurchaseOrderNumber = row["Purchase Order Number"].Cast<int>(),
                                InvoiceDate = row["Invoice Date"].Cast<DateTime>(),
                                InvoiceTotal = FormatCells.RemoveMonetaryCharacters(row["Invoice Total"].Cast<string>()),
                                Description = row["Description"].Cast<string>()
                            };

            db.Invoices.AddRange(query);
            db.SaveChanges();
        }
    }
}
