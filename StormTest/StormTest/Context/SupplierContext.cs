using StormTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StormTest.Context
{
    public class SupplierContext : DbContext
    {
        public SupplierContext() : base("name=SupplierContext")
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

    }
}