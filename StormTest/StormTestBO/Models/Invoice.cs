using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace StormTest.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        [Required]
        [DisplayName("Supplier Name")]
        public string Supplier { get; set; }
        [DisplayName("Invoice Type")]
        public string InvoiceType { get; set; }
        [Required]
        [DisplayName("Invoice Number")]
        public string InvoiceNumber { get; set; }
        [DisplayName("Purchase Order Number")]
        public int PurchaseOrderNumber { get; set; }
        [DisplayName("Invoice Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }
        [DisplayName("Invoice Total")]
        [DataType(DataType.Currency)]
        public double InvoiceTotal { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }




    }
}