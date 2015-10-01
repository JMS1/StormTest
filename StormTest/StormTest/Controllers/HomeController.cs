using StormTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormTest.Models;
using System.Data;
using System.Net;
using System.Data.Entity;

namespace StormTest.Controllers
{
    public class HomeController : Controller
    {
        SupplierContext db = new SupplierContext();
        // GET: Test
        

        public ActionResult Index()
        {
            SupplierContext db = new SupplierContext();
            var invoiceList = db.Invoices.ToList();
            return View(invoiceList);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            var invoiceTypeList = new SelectList(new[] { "INV", "CRD" });
            ViewBag.InvoiceTypeList = invoiceTypeList;

            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(invoice);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            var invoiceTypeList = new SelectList(new[] { "INV", "CRD" });
            ViewBag.InvoiceTypeList = invoiceTypeList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(invoice).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(invoice);
        }

         //GET: Test/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Invoice invoice = db.Invoices.Find(id);
                db.Invoices.Remove(invoice);
                db.SaveChanges();

            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}